using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class admin_gym_performance : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;"; // Replace with your connection string

        public admin_gym_performance()
        {
            InitializeComponent();
        }

        private void admin_gym_performance_Load(object sender, EventArgs e)
        {
            LoadGymInformation();
        }

        private void LoadGymInformation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT *, CAST(ROUND(RAND() * 5, 1) AS DECIMAL(3, 1)) AS ratings FROM gym";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Populate random ratings if needed
                    Random random = new Random();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["ratings"] == DBNull.Value)
                        {
                            row["ratings"] = random.Next(0, 51) / 10.0; // Random value between 0 and 5 with one decimal place
                        }
                    }

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;

                    // Sort by ratings
                    dataGridView1.Sort(dataGridView1.Columns["ratings"], ListSortDirection.Descending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadGymInformation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get gym id from textbox2
            int gymIdToDelete;
            if (!int.TryParse(textBox2.Text, out gymIdToDelete))
            {
                MessageBox.Show("Please enter a valid gym id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete from trainer_gym
                    string deleteTrainerGymQuery = "DELETE FROM trainer_gym WHERE gym_id = @GymId";
                    SqlCommand deleteTrainerGymCommand = new SqlCommand(deleteTrainerGymQuery, connection);
                    deleteTrainerGymCommand.Parameters.AddWithValue("@GymId", gymIdToDelete);
                    deleteTrainerGymCommand.ExecuteNonQuery();

                    // Delete from gym_owners
                    string deleteGymOwnersQuery = "DELETE FROM gym_owners WHERE gym_id = @GymId";
                    SqlCommand deleteGymOwnersCommand = new SqlCommand(deleteGymOwnersQuery, connection);
                    deleteGymOwnersCommand.Parameters.AddWithValue("@GymId", gymIdToDelete);
                    deleteGymOwnersCommand.ExecuteNonQuery();

                    // Delete from gym_locations
                    string deleteGymLocationsQuery = "DELETE FROM gym_locations WHERE gym_id = @GymId";
                    SqlCommand deleteGymLocationsCommand = new SqlCommand(deleteGymLocationsQuery, connection);
                    deleteGymLocationsCommand.Parameters.AddWithValue("@GymId", gymIdToDelete);
                    deleteGymLocationsCommand.ExecuteNonQuery();

                    // Delete from gym
                    string deleteGymQuery = "DELETE FROM gym WHERE gym_id = @GymId";
                    SqlCommand deleteGymCommand = new SqlCommand(deleteGymQuery, connection);
                    deleteGymCommand.Parameters.AddWithValue("@GymId", gymIdToDelete);
                    deleteGymCommand.ExecuteNonQuery();

                    MessageBox.Show("Data related to gym ID " + gymIdToDelete + " has been deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
