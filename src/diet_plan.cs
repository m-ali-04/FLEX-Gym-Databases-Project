using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class diet_plan : Form
    {
        string connectionString = "Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;";
        public diet_plan()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the diet plan ID from TextBox4
                int dietPlanId = Convert.ToInt32(textBox4.Text);

                // Check the user type
                if (UserInfo.Type.Equals("member", StringComparison.OrdinalIgnoreCase))
                {
                    // For members, insert the diet plan ID into active_wplans with the current user ID
                    InsertActiveDietPlan(dietPlanId);
                }
                else if (UserInfo.Type.Equals("trainer", StringComparison.OrdinalIgnoreCase))
                {
                    // For trainers, open the form for suggesting workouts
                    // You can replace "trainer_wsuggest" with the appropriate form name
                    trainer_dsuggest w = new trainer_dsuggest(dietPlanId);
                    w.Show();
                }

                MessageBox.Show("Diet plan activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertActiveDietPlan(int dietPlanId)
        {
            try
            {
                // Insert the diet plan ID into active_wplans with the current user ID
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to insert into active_wplans
                    string insertQuery = "INSERT INTO active_dplans (user_id, diet_plan_id, completion, trainer_id) VALUES (@UserId, @DietPlanId, @Completion, @TrainerId)";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters for user ID, diet plan ID, completion, and trainer ID
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        command.Parameters.AddWithValue("@DietPlanId", dietPlanId);
                        command.Parameters.AddWithValue("@Completion", 0); // Set completion to 0
                        command.Parameters.AddWithValue("@TrainerId", DBNull.Value); // Set trainer ID to null

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting diet plan into active plans: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select details of diet plans matching the current user
                    string query = @"
                SELECT dp.diet_plan_id, dp.goal, dp.calories, COUNT(ma.allergen_id) AS num_allergens, u.user_name AS created_by
                FROM diet_plan dp
                INNER JOIN users u ON dp.user_id = u.user_id
                LEFT JOIN diet_meal dm ON dp.diet_plan_id = dm.diet_plan_id
                LEFT JOIN meal_allergen ma ON dm.meal_id = ma.meal_id
                WHERE dp.user_id = @UserId
                GROUP BY dp.diet_plan_id, dp.goal, dp.calories, u.user_name";

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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select details of all diet plans
                    string query = @"
                SELECT dp.diet_plan_id, dp.goal, dp.calories, COUNT(ma.allergen_id) AS num_allergens, u.user_name AS created_by
                FROM diet_plan dp
                INNER JOIN users u ON dp.user_id = u.user_id
                LEFT JOIN diet_meal dm ON dp.diet_plan_id = dm.diet_plan_id
                LEFT JOIN meal_allergen ma ON dm.meal_id = ma.meal_id
                WHERE dp.created_by = 'member' -- Adjust the condition as needed
                GROUP BY dp.diet_plan_id, dp.goal, dp.calories, u.user_name";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select details of diet plans created by "Trainers"
                    string query = @"
                SELECT dp.diet_plan_id, dp.goal, dp.calories, COUNT(ma.allergen_id) AS num_allergens, u.user_name AS created_by
                FROM diet_plan dp
                INNER JOIN users u ON dp.user_id = u.user_id
                LEFT JOIN diet_meal dm ON dp.diet_plan_id = dm.diet_plan_id
                LEFT JOIN meal_allergen ma ON dm.meal_id = ma.meal_id
                WHERE dp.created_by = 'trainer' -- Adjust the condition as needed
                GROUP BY dp.diet_plan_id, dp.goal, dp.calories, u.user_name";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select details of all diet plans
                    string query = @"
                SELECT dp.diet_plan_id, dp.goal, dp.calories, COUNT(ma.allergen_id) AS num_allergens, u.user_name AS created_by
                FROM diet_plan dp
                INNER JOIN users u ON dp.user_id = u.user_id
                LEFT JOIN diet_meal dm ON dp.diet_plan_id = dm.diet_plan_id
                LEFT JOIN meal_allergen ma ON dm.meal_id = ma.meal_id
                GROUP BY dp.diet_plan_id, dp.goal, dp.calories, u.user_name";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the diet plan ID from TextBox4
                int dietPlanId = Convert.ToInt32(textBox4.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select details of meals in the specified diet plan
                    string query = @"
                SELECT m.meal_name, m.fat, m.protein, m.carbs, m.fiber, m.portion, m.meal_type
                FROM meal m
                INNER JOIN diet_meal dm ON m.meal_id = dm.meal_id
                WHERE dm.diet_plan_id = @DietPlanId";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the diet plan ID
                        command.Parameters.AddWithValue("@DietPlanId", dietPlanId);

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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
