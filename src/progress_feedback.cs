using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class progress_feedback : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";

        public progress_feedback()
        {
            InitializeComponent();
            LoadProgressFeedback();
            dataGridView1.Columns["comment"].Width = 500;
        }

        private void progress_feedback_Load(object sender, EventArgs e)
        {
            LoadProgressFeedback();

        }

        private void LoadProgressFeedback()
        {
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select progress feedback for the current user
                    string query = @"SELECT *
                                     FROM progress_feedback
                                     WHERE user_id = @UserId";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the user ID
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        

                        // Create a SqlDataAdapter to fill the DataTable with the results of the query
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable
                            adapter.Fill(dataTable);
                        }
                    }

                    // Bind the DataTable to dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading progress feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }

        private void progress_feedback_Shown(object sender, EventArgs e)
        {
            // Set the width of the comment column
             // Adjust the width as needed
        }
    }
}
