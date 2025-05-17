using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class trainer_wsuggest : Form
    {
        private string connectionString = "Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;";
        int workoutId = 0;
        int Tid = 0;
        public trainer_wsuggest(int w)
        {
            InitializeComponent();
            workoutId = w;

            // Subscribe to the Load event of the form
            this.Load += Trainer_wsuggest_Load;
        }

        private void Trainer_wsuggest_Load(object sender, EventArgs e)
        {
            LoadAppointmentsForTrainer();
            LoadWorkoutDetails(workoutId);
        }

        private void LoadAppointmentsForTrainer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select the trainerId for the current user from the trainers table
                    string trainerIdQuery = "SELECT trainer_id FROM trainers WHERE user_id = @UserId";

                    // Create a SqlCommand object to execute the trainerIdQuery
                    using (SqlCommand trainerIdCommand = new SqlCommand(trainerIdQuery, connection))
                    {
                        // Add parameter for the user ID
                        trainerIdCommand.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        // Execute the query to get the trainerId
                        int trainerId = Convert.ToInt32(trainerIdCommand.ExecuteScalar());
                        Tid = trainerId;
                        // Define the SQL query to select appointments for the trainer
                        string query = "SELECT u.user_id, u.user_name, u.user_age, u.user_contact " +
                                       "FROM appointment a " +
                                       "INNER JOIN users u ON a.user_id = u.user_id " +
                                       "WHERE a.trainer_id = @TrainerId";

                        // Create a DataTable to hold the results
                        DataTable dataTable = new DataTable();

                        // Create a SqlCommand object with the query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter for the trainer ID
                            command.Parameters.AddWithValue("@TrainerId", trainerId);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadWorkoutDetails(int workoutId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select the workout details based on workoutId
                    string query = @"SELECT w.workout_id, w.created_by, wi.experience_needed, wi.goal, wi.duration 
                             FROM workout_info wi
                             INNER JOIN workout w ON wi.workout_id = w.workout_id
                             WHERE w.workout_id = @WorkoutId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the workout ID
                        command.Parameters.AddWithValue("@WorkoutId", workoutId);

                        // Create a DataTable to hold the results
                        DataTable dataTable = new DataTable();

                        // Create a SqlDataAdapter to fill the DataTable with the results of the query
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable
                            adapter.Fill(dataTable);
                        }

                        // Bind the DataTable to dataGridView2
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading workout details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the user ID from textbox4
                int userId = int.Parse(textBox4.Text);

                // Set the completion status to 0
                int completion = 0;

                // Set the trainer ID (Tid)
                int trainerId = Tid; // Replace Tid with the actual trainer ID

                // Insert the workout into active_wplans
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to insert into active_wplans
                    string insertQuery = "INSERT INTO active_wplans (user_id, workout_id, completion, trainer_id) VALUES (@UserId, @WorkoutId, @Completion, @TrainerId)";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters for user ID, workout ID, completion, and trainer ID
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@WorkoutId", workoutId); // Assuming workoutId is already defined
                        command.Parameters.AddWithValue("@Completion", completion);
                        command.Parameters.AddWithValue("@TrainerId", trainerId);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }
                this.Close();
                // Display a success message
                MessageBox.Show("Workout added to active plans successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
