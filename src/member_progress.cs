using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class member_progress : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";

        public member_progress()
        {
            InitializeComponent();
        }

        private void member_progress_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select appointments for the current trainer ID
                    string query = @"SELECT u.user_id, u.user_name, u.user_age, u.user_contact 
                                     FROM appointment a 
                                     INNER JOIN users u ON a.user_id = u.user_id 
                                     WHERE a.trainer_id = (
                                         SELECT trainer_id FROM trainers WHERE user_id = @UserId
                                     )";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the current user ID
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
                MessageBox.Show("An error occurred while loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the member ID from TextBox1
                int memberId = int.Parse(textBox1.Text);

                // Fetch workout plans from active_wplan for the specified member and trainer
                DataTable workoutDataTable = FetchWorkoutPlans(memberId);

                // Fetch diet plans from active_dplan for the specified member and trainer
                DataTable dietDataTable = FetchDietPlans(memberId);

                // Bind the fetched workout plans to dataGridView2
                dataGridView2.DataSource = workoutDataTable;

                // Bind the fetched diet plans to dataGridView1
                dataGridView1.DataSource = dietDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable FetchWorkoutPlans(int memberId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT workout_id, completion, trainer_id
                             FROM active_wplans
                             WHERE user_id = @UserId AND trainer_id = (
                                 SELECT trainer_id FROM trainers WHERE user_id = @TrainerId
                             )";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", memberId);
                        command.Parameters.AddWithValue("@TrainerId", UserInfo.UserId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching workout plans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private DataTable FetchDietPlans(int memberId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT diet_plan_id, completion, trainer_id
                             FROM active_dplans
                             WHERE user_id = @UserId AND trainer_id = (
                                 SELECT trainer_id FROM trainers WHERE user_id = @TrainerId
                             )";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", memberId);
                        command.Parameters.AddWithValue("@TrainerId", UserInfo.UserId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching diet plans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add your dataGridView3 cell click event handler code here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the comment from textBox2
                string comment = textBox2.Text;

                // Get the member ID from textBox1
                int memberId = int.Parse(textBox1.Text);

                // Insert the comment into the progress_feedback table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to insert into the progress_feedback table
                    string insertQuery = @"INSERT INTO progress_feedback (user_id, trainer_id, comment)
                                   VALUES (@UserId, @TrainerId, @Comment)";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters for user ID, trainer ID, and comment
                        command.Parameters.AddWithValue("@UserId", memberId);
                        command.Parameters.AddWithValue("@TrainerId", UserInfo.UserId); // Assuming trainer ID is the same as user ID for now
                        command.Parameters.AddWithValue("@Comment", comment);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Feedback saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
