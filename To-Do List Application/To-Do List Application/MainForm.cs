using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace To_Do_List_Application
{
    public partial class MainForm : Form
    {
        private BindingSource bindingSource;
        private DatabaseManager databaseManager;
        private TableManager tableManager;

        private enum Status { All, Completed, UnCompleted };
        private enum Priority { None, Low, Medium, High };

        Status currentStatus = Status.All;
        Priority currentPriority = Priority.None;

        public MainForm()
        {
            InitializeComponent();

            databaseManager = new DatabaseManager();
            databaseManager.OpenConnection();

            tableManager = new TableManager(databaseManager.GetConnection());
            tableManager.CreateTable();

            bindingSource = new BindingSource();
            ToDoListView.DataSource = bindingSource;

            LoadData();
            ToDoListView.CellEndEdit += TodoListView_CellEndEdit;
            ToDoListView.CellFormatting += TodoListView_CellFormatting;
        }

        private void LoadData()
        {
            string tableFilters = "";
            if (currentStatus == Status.All)
            {
                tableFilters = "";
            }
            else if (currentStatus == Status.Completed)
            {
                tableFilters = " WHERE Status='Completed'";
            }
            else if (currentStatus == Status.UnCompleted)
            {
                tableFilters = " WHERE Status='Uncompleted'";
            }
            if (currentStatus == Status.All)
            {
                if (currentPriority == Priority.High)
                {
                    tableFilters = " WHERE Priority='High'";
                }
                else if (currentPriority == Priority.Medium)
                {
                    tableFilters = " WHERE Priority='Medium'";
                }
                else if (currentPriority == Priority.Low)
                {
                    tableFilters = " WHERE Priority='Low'";
                }
            }
            else
            {
                if (currentPriority == Priority.High)
                {
                    tableFilters += " AND Priority='High'";
                }
                else if (currentPriority == Priority.Medium)
                {
                    tableFilters += " AND Priority='Medium'";
                }
                else if (currentPriority == Priority.Low)
                {
                    tableFilters += " AND Priority='Low'";
                }
            }
            string selectQuery = $"SELECT * FROM ToDoListTable{tableFilters};";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, databaseManager.GetConnection());
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            // Hides the id column
            ToDoListView.Columns[0].Visible = false;
        }

        private void TodoListView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Get the edited cell's value
            object editedValue = ToDoListView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            // Get the primary key from the first column
            int primaryKeyValue = Convert.ToInt32(ToDoListView.Rows[e.RowIndex].Cells[0].Value);

            // Update the corresponding row in the database
            UpdateDatabase(primaryKeyValue, e.ColumnIndex, editedValue);
        }

        private void TodoListView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                // Sets column index to Status column
                int completeColumnIndex = 1;

                // Check if the cell contains "Completed"
                if (ToDoListView.Rows[e.RowIndex].Cells[completeColumnIndex].Value.ToString() == "Completed")
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                // Check if the cell contains "Uncompleted"
                else if (ToDoListView.Rows[e.RowIndex].Cells[completeColumnIndex].Value.ToString() == "Uncompleted")
                {
                    e.CellStyle.BackColor = Color.DarkRed;
                }
                else
                {
                    // Reset the background color for other values
                    e.CellStyle.BackColor = ToDoListView.DefaultCellStyle.BackColor;
                }
            }
        }


        private void UpdateDatabase(int primaryKeyValue, int columnIndex, object editedValue)
        {
            string columnName = "";
            if (columnIndex == 0) { columnName = "ID"; }
            else if (columnIndex == 1) { columnName = "Status"; }
            else if (columnIndex == 2) { columnName = "Name"; }
            else if (columnIndex == 3) { columnName = "Description"; }
            else if (columnIndex == 4) { columnName = "DueDate"; }
            else if (columnIndex == 5) { columnName = "Priority"; }
            // Update the corresponding row in the SQLite database
            string updateQuery = $"UPDATE ToDoListTable SET {columnName} = @EditedValue WHERE ID = @PrimaryKeyValue;";

            using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, databaseManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@EditedValue", editedValue);
                cmd.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue);

                databaseManager.OpenConnection();
                cmd.ExecuteNonQuery();
                databaseManager.CloseConnection();
            }
            LoadData();
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            // Insert data into the SQLite database
            string insertQuery = "INSERT INTO ToDoListTable (Status, Name, Description, DueDate, Priority) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5);";
            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, databaseManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Column1", "Uncompleted");
                cmd.Parameters.AddWithValue("@Column2", "");
                cmd.Parameters.AddWithValue("@Column3", "");
                cmd.Parameters.AddWithValue("@Column4", "");
                cmd.Parameters.AddWithValue("@Column5", "");

                databaseManager.OpenConnection();
                cmd.ExecuteNonQuery();
                databaseManager.CloseConnection();
            }

            // Refresh the DataGridView
            LoadData();
        }

        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {
            // Check if any rows are selected
            if (ToDoListView.SelectedRows.Count > 0)
            {
                // Loop through the selected rows and delete each one
                foreach (DataGridViewRow row in ToDoListView.SelectedRows)
                {
                    int primaryKeyValue = Convert.ToInt32(row.Cells[0].Value);
                    DeleteRow(primaryKeyValue);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeleteRow(int primaryKeyValue)
        {
            // Delete the corresponding row in the SQLite database
            string deleteQuery = "DELETE FROM ToDoListTable WHERE ID = @PrimaryKeyValue;";

            using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, databaseManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue);

                databaseManager.OpenConnection();
                cmd.ExecuteNonQuery();
                databaseManager.CloseConnection();
            }

            // Refresh the DataGridView after deletion
            LoadData();
        }

        private void AllBtn_Click(object sender, EventArgs e)
        {
            currentStatus = Status.All;

            AllBtn.BackColor = Color.LightGray;
            CompletedBtn.BackColor = Color.White;
            UncompletedBtn.BackColor = Color.White;

            LoadData();
        }

        private void CompletedBtn_Click(object sender, EventArgs e)
        {
            currentStatus = Status.Completed;

            AllBtn.BackColor = Color.White;
            CompletedBtn.BackColor = Color.LightGray;
            UncompletedBtn.BackColor = Color.White;

            LoadData();
        }

        private void UncompletedBtn_Click(object sender, EventArgs e)
        {
            currentStatus = Status.UnCompleted;

            AllBtn.BackColor = Color.White;
            CompletedBtn.BackColor = Color.White;
            UncompletedBtn.BackColor = Color.LightGray;

            LoadData();
        }

        private void HighPriorityBtn_Click(object sender, EventArgs e)
        {
            if (currentPriority == Priority.High)
            {
                currentPriority = Priority.None;
                HighPriorityBtn.BackColor = Color.White;
            }
            else
            {
                currentPriority = Priority.High;
                HighPriorityBtn.BackColor = Color.LightGray;
                MediumPriorityBtn.BackColor = Color.White;
                LowPriorityBtn.BackColor = Color.White;
            }
            LoadData();
        }

        private void MediumPriorityBtn_Click(object sender, EventArgs e)
        {
            if (currentPriority == Priority.Medium)
            {
                currentPriority = Priority.None;
                MediumPriorityBtn.BackColor = Color.White;
            }
            else
            {
                currentPriority = Priority.Medium;
                HighPriorityBtn.BackColor = Color.White;
                MediumPriorityBtn.BackColor = Color.LightGray;
                LowPriorityBtn.BackColor = Color.White;
            }
            LoadData();
        }

        private void LowPriorityBtn_Click(object sender, EventArgs e)
        {
            if (currentPriority == Priority.Low)
            {
                currentPriority = Priority.None;
                LowPriorityBtn.BackColor = Color.White;
            }
            else
            {
                currentPriority = Priority.Low;
                HighPriorityBtn.BackColor = Color.White;
                MediumPriorityBtn.BackColor = Color.White;
                LowPriorityBtn.BackColor = Color.LightGray;
            }
            LoadData();
        }
    }
    public class DatabaseManager
    {
        private SQLiteConnection connection;

        public DatabaseManager()
        {
            string databasePath = "C:\\Users\\rgaet\\OneDrive\\Documents\\GitHub\\To-Do_List_Application\\To-Do List Application\\To-Do List Application\\Resources\\DatabaseFolder\\Database.db";

            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            string connectionString = $"Data Source={databasePath};Version=3;";
            connection = new SQLiteConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }
    }

    public class TableManager
    {
        private SQLiteCommand command;

        public TableManager(SQLiteConnection connection)
        {
            command = new SQLiteCommand(connection);
        }

        public void CreateTable()
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ToDoListTable (ID INTEGER PRIMARY KEY AUTOINCREMENT, Status TEXT, Name TEXT, Description TEXT, DueDate TEXT, Priority TEXT);";

            command.CommandText = createTableQuery;
            command.ExecuteNonQuery();
        }
    }
}