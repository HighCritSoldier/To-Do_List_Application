using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace To_Do_List_Application
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data Source=Database.db;Version=3;";
        private string tableName = "ToDoListDB";

        private SQLiteDataAdapter dataAdapter;
        private DataTable dataTable;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateTable();
            LoadData();
        }

        private void CreateTable()
        {
            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a new SQLite command
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    // SQL statement to create the table if it doesn't exist
                    string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS ToDoListDB (
                        Status BOOLEAN,
                        Name TEXT,
                        Description TEXT,
                        DueDate DATE
                    )";

                    // Set the command text to the SQL statement
                    command.CommandText = createTableQuery;

                    // Execute the SQL statement
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                // Close the connection
                connection.Close();
            }
        }

        private void LoadData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter())
                {
                    dataAdapter.SelectCommand = new SQLiteCommand($"SELECT * FROM {tableName}", connection);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    ToDoListView.DataSource = dataTable;
                }

                connection.Close();
            }
        }

        private void TodoListView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Update the database when a cell's editing is complete
            dataAdapter.Update(dataTable);
        }

        private void AddItemBtn_Click(object sender, EventArgs e)
        {
            // Adds an empty row with no defaults
            ToDoListView.Rows.Add(false, "", "", "");
        }

        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {
            // Check if there is a selected row
            if (ToDoListView.SelectedRows.Count > 0)
            {
                // Get the selected row(s)
                DataGridViewRow selectedRow = ToDoListView.SelectedRows[0];

                // Remove the selected row(s) from the DataGridView
                ToDoListView.Rows.Remove(selectedRow);
            }
        }
    }
}