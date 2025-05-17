using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class member_booking : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";

        public member_booking()
        {
            InitializeComponent();
        }

        private void member_booking_Load(object sender, EventArgs e)
        {
            LoadTrainerInfo();
            LoadAppointments();
            LoadApprovedAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select appointments based on user ID and approval status
                    string query = @"SELECT app_id, user_id, trainer_id, schedule
                             FROM appointment
                             WHERE user_id = @UserId AND approval = 0";

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

                    // Bind the DataTable to dataGridView2
                    dataGridView2.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApprovedAppointments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select approved appointments for the current user
                    string query = @"SELECT app_id, user_id, trainer_id, schedule
                             FROM appointment
                             WHERE approval = 1 AND user_id = @UserId";

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

                    // Bind the DataTable to dataGridView3
                    dataGridView3.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading approved appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainerInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT t.trainer_id, u.user_name AS TrainerName, ti.rating, ti.gym_num, ti.qualification, ti.experience, ti.specialty
                                     FROM trainer_info ti
                                     INNER JOIN trainers t ON ti.trainer_id = t.trainer_id
                                     INNER JOIN users u ON t.user_id = u.user_id";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading trainer information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            member_db f = new member_db();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Your button3 click event handler code here
        }

        private void button6_Click(object sender, EventArgs e)
        {
            progress_feedback progress = new progress_feedback();
            progress.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Your dataGridView1 cell content click event handler code here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the trainer ID from TextBox2
                int trainerId = int.Parse(textBox2.Text);

                // Get the schedule from DateTimePicker1 and convert it to string
                string schedule = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

                // Insert into appointment table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to insert into the appointment table
                    string insertQuery = @"INSERT INTO appointment (user_id, trainer_id, schedule, workout_id, diet_plan_id, approval)
                           VALUES (@UserId, @TrainerId, @Schedule, NULL, NULL, 0)";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters for user ID, trainer ID, and schedule
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        command.Parameters.AddWithValue("@TrainerId", trainerId);
                        command.Parameters.AddWithValue("@Schedule", schedule);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }
                LoadAppointments();
                MessageBox.Show("Appointment scheduled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            member_rating member_Rating = new member_rating();
            member_Rating.Show();
        }
    }
}
