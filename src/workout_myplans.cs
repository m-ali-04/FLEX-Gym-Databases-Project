using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project
{
    public partial class workout_myplans : Form
    {
        public workout_myplans()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                {
                    connection.Open();

                    // Define your SQL query to select data from multiple tables
                    string query = "SELECT w.workout_id, wi.experience_needed, wi.goal, wi.duration, " +
                                   "(SELECT COUNT(ce.chosen_exercise_id) FROM chosen_exercise ce WHERE ce.workout_id = w.workout_id) AS num_chosen_exercises, " +
                                   "w.created_by, u.user_name " +
                                   "FROM workout w " +
                                   "INNER JOIN workout_info wi ON w.workout_id = wi.workout_id " +
                                   "INNER JOIN users u ON w.user_id = u.user_id " +
                                   "WHERE w.created_by = 'member'";

                    // Create a DataTable to hold the results of the query
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable with the results of the query
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                {
                    connection.Open();

                    // Define your SQL query to select data from multiple tables
                    string query = "SELECT w.workout_id, wi.experience_needed, wi.goal, wi.duration, " +
                                   "(SELECT COUNT(ce.chosen_exercise_id) FROM chosen_exercise ce WHERE ce.workout_id = w.workout_id) AS num_of_exercises, " +
                                   "u.user_name " +
                                   "FROM workout w " +
                                   "INNER JOIN workout_info wi ON w.workout_id = wi.workout_id " +
                                   "INNER JOIN users u ON w.user_id = u.user_id " +
                                   "WHERE u.user_id = @UserId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for filtering by user ID
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        // Create a DataTable to hold the results of the query
                        DataTable dataTable = new DataTable();

                        // Create a SqlDataAdapter to fill the DataTable with the results of the query
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable
                            adapter.Fill(dataTable);
                        }

                        // Bind the DataTable to dataGridView1
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                {
                    connection.Open();

                    // Define your SQL query to select data from multiple tables
                    string query = "SELECT w.workout_id, wi.experience_needed, wi.goal, wi.duration, " +
                                   "(SELECT COUNT(ce.chosen_exercise_id) FROM chosen_exercise ce WHERE ce.workout_id = w.workout_id) AS num_chosen_exercises, " +
                                   "w.created_by, u.user_name " +
                                   "FROM workout w " +
                                   "INNER JOIN workout_info wi ON w.workout_id = wi.workout_id " +
                                   "INNER JOIN users u ON w.user_id = u.user_id ";

                    // Create a DataTable to hold the results of the query
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable with the results of the query
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                {
                    connection.Open();

                    // Define your SQL query to select data from multiple tables
                    string query = "SELECT w.workout_id, wi.experience_needed, wi.goal, wi.duration, " +
                                   "(SELECT COUNT(ce.chosen_exercise_id) FROM chosen_exercise ce WHERE ce.workout_id = w.workout_id) AS num_chosen_exercises, " +
                                   "w.created_by, u.user_name " +
                                   "FROM workout w " +
                                   "INNER JOIN workout_info wi ON w.workout_id = wi.workout_id " +
                                   "INNER JOIN users u ON w.user_id = u.user_id " +
                                   "WHERE w.created_by like 'Trainer'";

                    // Create a DataTable to hold the results of the query
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable with the results of the query
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the workout ID from the textbox
                if (int.TryParse(textBox4.Text, out int workoutId))
                {
                    using (SqlConnection connection = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                    {
                        connection.Open();

                        // Define your SQL query to select chosen exercises with exercise information
                        string query = "SELECT ce.exercise_id, e.exercise_name, e.target_muscle, e.machine_id, ce.reps, ce.sets " +
                                       "FROM chosen_exercise ce " +
                                       "INNER JOIN exercises e ON ce.exercise_id = e.exerccise_id " +
                                       "WHERE ce.workout_id = @WorkoutId";

                        // Create a SqlCommand object with the query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter for filtering by workout ID
                            command.Parameters.AddWithValue("@WorkoutId", workoutId);

                            // Create a DataTable to hold the results of the query
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
                else
                {
                    MessageBox.Show("Please enter a valid workout ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the workout ID from TextBox4
                int workoutId = Convert.ToInt32(textBox4.Text);

                // Check the user type
                if (UserInfo.Type.Equals("member", StringComparison.OrdinalIgnoreCase))
                {
                    // For members, insert the workout ID into active_wplans with the current user ID
                    InsertActiveWorkoutPlan(workoutId);
                }
                else if (UserInfo.Type.Equals("trainer", StringComparison.OrdinalIgnoreCase))
                {
                    trainer_wsuggest w = new trainer_wsuggest(workoutId);
                    w.Show();
                }
                

                MessageBox.Show("Workout plan activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertActiveWorkoutPlan(int workoutId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to insert into active_wplans
                    string query = "INSERT INTO active_wplans (user_id, workout_id, completion, trainer_id) " +
                                   "VALUES (@UserId, @WorkoutId, 0, NULL)";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for user ID and workout ID
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        command.Parameters.AddWithValue("@WorkoutId", workoutId);

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting the active workout plan: " + ex.Message);
            }
        }

        private void workout_myplans_Load(object sender, EventArgs e)
        {

        }
    }
}
