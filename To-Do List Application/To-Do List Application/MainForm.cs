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

        Status currentStatus = Status.All;

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

            FormClosing += MainForm_FormClosing;
            ToDoListView.CellEndEdit += TodoListView_CellEndEdit;
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
            string selectQuery = $"SELECT * FROM ToDoListTable{tableFilters};";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, databaseManager.GetConnection());
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            // Hides the id column
            ToDoListView.Columns[0].Visible = false;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save any changes to the SQLite database before closing the form
            SaveChanges();
        }

        private void SaveChanges()
        {
            if (ToDoListView.DataSource is DataTable dataTable)
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM ToDoListTable", databaseManager.GetConnection()))
                {
                    using (SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(adapter))
                    {
                        adapter.Update(dataTable);
                    }
                }
            }

            // Close the database connection
            databaseManager.CloseConnection();
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

        private void UpdateDatabase(int primaryKeyValue, int columnIndex, object editedValue)
        {
            string columnName = "";
            if (columnIndex == 0)
            {
                columnName = "ID";
            }
            else if (columnIndex == 1)
            {
                columnName = "Status";
            }
            else if (columnIndex == 2)
            {
                columnName = "Name";
            }
            else if (columnIndex == 3)
            {
                columnName = "Description";
            }
            else if (columnIndex == 4)
            {
                columnName = "DueDate";
            }
            else if (columnIndex == 5)
            {
                columnName = "Priority";
            }
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