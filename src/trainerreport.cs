using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class trainerreport : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";

        public trainerreport()
        {
            InitializeComponent();
        }

        private void trainerreport_Load(object sender, EventArgs e)
        {
            LoadTrainerReport();
        }

        private void LoadTrainerReport()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT t.trainer_id, t.user_id, u.user_name, ti.rating, ti.qualification, 
                                        (SELECT COUNT(*) FROM appointment WHERE trainer_id = t.trainer_id) AS TotalClients,
                                        ti.experience
                                    FROM trainers t
                                    INNER JOIN users u ON t.user_id = u.user_id
                                    LEFT JOIN trainer_info ti ON t.trainer_id = ti.trainer_id
                                    ORDER BY ti.experience DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    // Bind the DataTable to DataGridView
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTrainersByExperience();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadTrainersByRating();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadTrainersByClients();
        }

        private void LoadTrainersByExperience()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT t.trainer_id, t.user_id, u.user_name, ti.rating, ti.qualification, 
                                (SELECT COUNT(*) FROM appointment WHERE trainer_id = t.trainer_id) AS TotalClients,
                                ti.experience
                            FROM trainers t
                            INNER JOIN users u ON t.user_id = u.user_id
                            LEFT JOIN trainer_info ti ON t.trainer_id = ti.trainer_id
                            ORDER BY ti.experience DESC";

                    LoadTrainerData(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainersByRating()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT t.trainer_id, t.user_id, u.user_name, ti.rating, ti.qualification, 
                                (SELECT COUNT(*) FROM appointment WHERE trainer_id = t.trainer_id) AS TotalClients,
                                ti.experience
                            FROM trainers t
                            INNER JOIN users u ON t.user_id = u.user_id
                            LEFT JOIN trainer_info ti ON t.trainer_id = ti.trainer_id
                            ORDER BY ti.rating DESC";

                    LoadTrainerData(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainersByClients()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT t.trainer_id, t.user_id, u.user_name, ti.rating, ti.qualification, 
                                (SELECT COUNT(*) FROM appointment WHERE trainer_id = t.trainer_id) AS TotalClients,
                                ti.experience
                            FROM trainers t
                            INNER JOIN users u ON t.user_id = u.user_id
                            LEFT JOIN trainer_info ti ON t.trainer_id = ti.trainer_id
                            ORDER BY TotalClients DESC";

                    LoadTrainerData(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainerData(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    // Bind the DataTable to DataGridView
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
