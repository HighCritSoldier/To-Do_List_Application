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
        private SQLiteCommand command;
        private string CategoryFilter = "";

        private enum Status { All, Completed, UnCompleted };
        private enum Priority { None, Low, Medium, High };
        private enum Date { None, Today, Tomorrow, ThisWeek, PastDue };

        Status currentStatus = Status.All;
        Priority currentPriority = Priority.None;
        Date dateSelected = Date.None;

        /*
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.AddDays(1);
        DateTime twoDaysFromNow = DateTime.Today.AddDays(2);
        DateTime threeDaysFromNow = DateTime.Today.AddDays(3);
        DateTime fourDaysFromNow = DateTime.Today.AddDays(4);
        DateTime fiveDaysFromNow = DateTime.Today.AddDays(5);
        DateTime sixDaysFromNow = DateTime.Today.AddDays(6);
        */

        public MainForm()
        {
            InitializeComponent();

            databaseManager = new DatabaseManager();
            databaseManager.OpenConnection();

            tableManager = new TableManager(databaseManager.GetConnection());
            tableManager.CreateTable();
            tableManager.CreateCategories();

            bindingSource = new BindingSource();
            ToDoListView.DataSource = bindingSource;

            LoadData();
            LoadCategories();
            ToDoListView.CellEndEdit += TodoListView_CellEndEdit;
            ToDoListView.CellFormatting += TodoListView_CellFormatting;
        }

        private void LoadData()
        {
            string tableFilters = "";
            int filterCount = 0;
            bool hasStatus = false;
            bool hasPriority = false;
            bool hasDate = false;
            bool hasCategory = false;

            if (currentStatus != Status.All) { filterCount++; }
            if (currentPriority != Priority.None) { filterCount++; }
            if (dateSelected != Date.None) { filterCount++; }
            if (CategoryFilter != "None") { filterCount++; }

            if (filterCount != 0)
            {
                for (int i = 1; i <= filterCount; i++)
                {
                    if (i == 1) { tableFilters += " WHERE "; }
                    if (i != 1) { tableFilters += " AND "; }
                    if (!hasStatus)
                    {
                        if (currentStatus == Status.Completed)
                        {
                            tableFilters += "Status='Completed'";
                            hasStatus = true;
                            continue;
                        }
                        else if (currentStatus == Status.UnCompleted)
                        {
                            tableFilters += "Status='Uncompleted'";
                            hasStatus = true;
                            continue;
                        }
                    }
                    if (!hasPriority)
                    {
                        if (currentPriority == Priority.High)
                        {
                            tableFilters += "Priority='High'";
                            hasPriority = true;
                            continue;
                        }
                        else if (currentPriority == Priority.Medium)
                        {
                            tableFilters += "Priority='Medium'";
                            hasPriority = true;
                            continue;
                        }
                        else if (currentPriority == Priority.Low)
                        {
                            tableFilters += "Priority='Low'";
                            hasPriority = true;
                            continue;
                        }
                    }
                    if (!hasDate)
                    {
                        if (dateSelected == Date.Today)
                        {
                            tableFilters += "DueDate = Date('now')";
                            hasDate = true;
                            continue;
                        }
                        else if (dateSelected == Date.Tomorrow)
                        {
                            tableFilters += "DueDate = Date('now', '+1 day')";
                            hasDate = true;
                            continue;
                        }
                        else if (dateSelected == Date.ThisWeek)
                        {
                            tableFilters += "DueDate BETWEEN Date('now') AND Date('now', '+5 day')";
                            hasDate = true;
                            continue;
                        }
                        else if (dateSelected == Date.PastDue)
                        {
                            tableFilters += "DueDate < Date('now')";
                            hasDate = true;
                            continue;
                        }
                    }
                    if (!hasCategory)
                    {
                        if (CategoryFilter != "None")
                        {
                            tableFilters += $"Category LIKE '%{CategoryFilter}%'";
                            hasCategory = true;
                            continue;
                        }
                    }
                }
            }
            try
            {
                string selectQuery = $"SELECT * FROM ToDoListTable{tableFilters};";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectQuery, databaseManager.GetConnection());
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

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
            else if (columnIndex == 3) { columnName = "Category"; }
            else if (columnIndex == 4) { columnName = "Description"; }
            else if (columnIndex == 5) { columnName = "DueDate"; }
            else if (columnIndex == 6) { columnName = "Priority"; }
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
            string insertQuery = "INSERT INTO ToDoListTable (Status, Name, Category, Description, DueDate, Priority) VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6);";
            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, databaseManager.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Column1", "Uncompleted");
                cmd.Parameters.AddWithValue("@Column2", "");
                cmd.Parameters.AddWithValue("@Column3", "");
                cmd.Parameters.AddWithValue("@Column4", "");
                cmd.Parameters.AddWithValue("@Column5", "");
                cmd.Parameters.AddWithValue("@Column6", "");

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

        private void TodayBtn_Click(object sender, EventArgs e)
        {
            if (dateSelected == Date.Today)
            {
                dateSelected = Date.None;
                TodayBtn.BackColor = Color.White;
            }
            else
            {
                dateSelected = Date.Today;
                TodayBtn.BackColor = Color.LightGray;
                TomorrowBtn.BackColor = Color.White;
                ThisWeekBtn.BackColor = Color.White;
                PastDueBtn.BackColor = Color.White;
            }
            LoadData();
        }

        private void TomorrowBtn_Click(object sender, EventArgs e)
        {
            if (dateSelected == Date.Tomorrow)
            {
                dateSelected = Date.None;
                TomorrowBtn.BackColor = Color.White;
            }
            else
            {
                dateSelected = Date.Tomorrow;
                TodayBtn.BackColor = Color.White;
                TomorrowBtn.BackColor = Color.LightGray;
                ThisWeekBtn.BackColor = Color.White;
                PastDueBtn.BackColor = Color.White;
            }
            LoadData();
        }

        private void ThisWeekBtn_Click(object sender, EventArgs e)
        {
            if (dateSelected == Date.ThisWeek)
            {
                dateSelected = Date.None;
                ThisWeekBtn.BackColor = Color.White;
            }
            else
            {
                dateSelected = Date.ThisWeek;
                TodayBtn.BackColor = Color.White;
                TomorrowBtn.BackColor = Color.White;
                ThisWeekBtn.BackColor = Color.LightGray;
                PastDueBtn.BackColor = Color.White;
            }
            LoadData();
        }

        private void PastDueBtn_Click(object sender, EventArgs e)
        {
            if (dateSelected == Date.PastDue)
            {
                dateSelected = Date.None;
                PastDueBtn.BackColor = Color.White;
            }
            else
            {
                dateSelected = Date.PastDue;
                TodayBtn.BackColor = Color.White;
                TomorrowBtn.BackColor = Color.White;
                ThisWeekBtn.BackColor = Color.White;
                PastDueBtn.BackColor = Color.LightGray;
            }
            LoadData();
        }

        private void CategoryAddTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13) // 13 is the Enter key code
            {
                try
                {
                    string addQuery = "Insert INTO Categories (Name) VALUES (@AddValue)";
                    string addValue = CategoryAddTxtBox.Text;

                    using (SQLiteCommand cmd = new SQLiteCommand(addQuery, databaseManager.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@AddValue", addValue);

                        databaseManager.OpenConnection();
                        cmd.ExecuteNonQuery();
                        databaseManager.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                LoadCategories();

                CategoryAddTxtBox.Text = string.Empty;
                // Prevent the TextBox from inserting a newline character (Enter key)
                e.Handled = true;
            }
        }

        private void LoadCategories()
        {
            CategoryListBox.Items.Clear();

            string query = "SELECT Name FROM Categories;";
            databaseManager.OpenConnection();
            using (SQLiteCommand command = new SQLiteCommand(query, databaseManager.GetConnection()))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        CategoryListBox.Items.Add(name);
                    }
                }
            }
            databaseManager.CloseConnection();
        }

        private void CategoryFilterBtn_Click(object sender, EventArgs e)
        {
            if (CategoryListBox.SelectedItems.Count > 0)
            {
                CategoryFilter = CategoryListBox.SelectedItem.ToString();
                LoadCategories();
                LoadData();
            }
            else
            {
                MessageBox.Show("Please choose a category to filter.");
            }
        }

        private void DeleteCategoryBtn_Click(object sender, EventArgs e)
        {
            if (CategoryListBox.SelectedItems.Count > 0)
            {
                string deleteQuery = "DELETE FROM Categories WHERE Name = @NameValue;";
                string NameValue = CategoryListBox.SelectedItem.ToString();

                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, databaseManager.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@NameValue", NameValue);

                    databaseManager.OpenConnection();
                    cmd.ExecuteNonQuery();
                    databaseManager.CloseConnection();
                }
                if (NameValue == CategoryFilter)
                {
                    CategoryFilter = "None";
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please choose a category to delete.");
            }
            LoadCategories();
        }

        private void RemoveCategoryFilterBtn_Click(object sender, EventArgs e)
        {
            CategoryFilter = "None";
            LoadCategories();
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
            string createTableQuery = "CREATE TABLE IF NOT EXISTS ToDoListTable (ID INTEGER PRIMARY KEY AUTOINCREMENT, Status TEXT, Name TEXT, Category TEXT, Description TEXT, DueDate TEXT, Priority TEXT);";
            command.CommandText = createTableQuery;
            command.ExecuteNonQuery();
        }

        public void CreateCategories()
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS Categories (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT);";
            command.CommandText = createTableQuery;
            command.ExecuteNonQuery();
        }
    }
}