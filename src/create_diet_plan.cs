using System;
using System.Collections.Concurrent;
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
    
    public partial class create_diet_plan : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";
        bool saved = false;
        private int currentD = 0;

        // Define nutrient thresholds dictionary
        private Dictionary<string, int> nutrientThresholds = new Dictionary<string, int>
        {
            { "Protein", 20 },
            { "Fat", 10 },
            { "Carbohydrate", 50 },
            { "Fiber", 5 }
        };

        public create_diet_plan()
        {
            InitializeComponent();
            this.Load += create_diet_plan_Load; // Attach the event handler to the Load event
        }

        private void create_diet_plan_Load(object sender, EventArgs e)
        {
            LoadExistingDietPlans();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM meal WHERE 1=1";

                    // Check if comboBox2 is selected and filter by meal_type
                    if (!string.IsNullOrEmpty(comboBox2.Text))
                    {
                        query += $" AND meal_type = '{comboBox2.Text}'";
                    }

                    // Check if comboBox1 is selected and filter out meals with allergens
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        query += $" AND meal_id NOT IN (SELECT meal_id FROM meal_allergen ma JOIN allergens a ON ma.allergen_id = a.allergen_id WHERE a.allergen = '{comboBox1.Text}')";
                    }

                    // Check if comboBox3 is selected and filter by the specified nutrient
                    if (!string.IsNullOrEmpty(comboBox3.Text) && nutrientThresholds.ContainsKey(comboBox3.Text))
                    {
                        string nutrient = comboBox3.Text.ToLower();
                        int threshold = nutrientThresholds[comboBox3.Text];
                        query += $" AND {nutrient} > {threshold}";
                    }

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable with the results of the query
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
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
            CreateDietPlan();
        }

        private void CreateDietPlan()
        {
            try
            {
                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Define the SQL INSERT query for the diet_plan table
                    string query = "INSERT INTO diet_plan (user_id, created_by) VALUES (@UserId, @CreatedBy);" +
                        "SELECT SCOPE_IDENTITY();"; // Retrieve the generated diet_plan_id

                    // Create SqlCommand with the INSERT query and connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        cmd.Parameters.AddWithValue("@CreatedBy", UserInfo.Type);

                        // Execute the query and retrieve the generated ID
                        currentD = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the generated ID
                        MessageBox.Show("Diet plan created successfully! Generated Diet Plan ID: " + currentD);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMealToDietPlan();
        }

        private void AddMealToDietPlan()
        {
            try
            {
                // Get the meal ID from TextBox4
                int mealId = Convert.ToInt32(textBox4.Text);

                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Define the SQL INSERT query for adding the meal to the diet plan
                    string query = "INSERT INTO diet_meal (diet_plan_id, meal_id) VALUES (@DietPlanId, @MealId)";

                    // Create SqlCommand with the INSERT query and connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@DietPlanId", currentD);
                        cmd.Parameters.AddWithValue("@MealId", mealId);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                // Reload chosen meals into dataGridView2
                LoadChosenMeals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadChosenMeals()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select chosen meals for the current diet plan
                    string query = "SELECT m.meal_id, m.meal_name, m.meal_type FROM diet_meal dm " +
                                   "JOIN meal m ON dm.meal_id = m.meal_id " +
                                   "WHERE dm.diet_plan_id = @DietPlanId";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the diet plan ID
                        command.Parameters.AddWithValue("@DietPlanId", currentD);

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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadExistingDietPlans()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select existing diet plans for the current user
                    string query = "SELECT diet_plan_id, goal, calories FROM diet_plan WHERE user_id = @UserId";

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
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there is a current diet plan
                if (currentD == 0)
                {
                    MessageBox.Show("No current diet plan created.");
                    return;
                }

                // Calculate total calories for the current diet plan
                int totalCalories = CalculateTotalDietPlanCalories(currentD);

                // Update the calories and goal for the current diet plan in the database
                UpdateDietPlan(currentD, totalCalories);

                // Display a success message
                MessageBox.Show("Calories calculated and updated for the current diet plan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the existing diet plans in dataGridView3
                LoadExistingDietPlans();
                saved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDietPlan(int dietPlanId, int totalCalories)
        {
            try
            {
                string goal = DetermineGoal(totalCalories);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to update the calories and goal for the specified diet plan
                    string updateQuery = "UPDATE diet_plan SET calories = @Calories, goal = @Goal WHERE diet_plan_id = @DietPlanId";

                    // Create a SqlCommand object with the update query and connection
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters for the calories, goal, and diet plan ID
                        updateCommand.Parameters.AddWithValue("@Calories", totalCalories);
                        updateCommand.Parameters.AddWithValue("@Goal", goal);
                        updateCommand.Parameters.AddWithValue("@DietPlanId", dietPlanId);

                        // Execute the update query
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating diet plan: " + ex.Message);
            }
        }

        private string DetermineGoal(int totalCalories)
        {
            // Assumptions for goal determination based on total calories
            if (totalCalories < 2000)
            {
                return "Weight Loss";
            }
            else if (totalCalories >= 2000 && totalCalories < 3000)
            {
                return "Weight Gain";
            }
            else if (totalCalories >= 3000 && totalCalories < 4000)
            {
                return "Muscle Growth";
            }
            else if (totalCalories >= 4000 && totalCalories < 5000)
            {
                return "Competition";
            }
            else
            {
                return "Stamina";
            }
        }

        private int CalculateTotalDietPlanCalories(int dietPlanId)
        {
            int totalCalories = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select the meals associated with the specified diet plan
                    string query = @"
                SELECT m.protein, m.carbs, m.fat, m.portion 
                FROM meal m 
                INNER JOIN diet_meal dpm ON m.meal_id = dpm.meal_id 
                WHERE dpm.diet_plan_id = @DietPlanId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for the diet plan ID
                        command.Parameters.AddWithValue("@DietPlanId", dietPlanId);

                        // Execute the query and get a data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Iterate through the results and calculate the calories for each meal
                            while (reader.Read())
                            {
                                int protein = Convert.ToInt32(reader["protein"]);
                                int carbs = Convert.ToInt32(reader["carbs"]);
                                int fat = Convert.ToInt32(reader["fat"]);
                                int portion = Convert.ToInt32(reader["portion"]);

                                // Calculate the calories for the current meal
                                int mealCalories = CalculateMealCalories(protein, carbs, fat, portion);

                                // Add the calories for the current meal to the total
                                totalCalories += mealCalories;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating total calories for the diet plan: " + ex.Message);
            }

            return totalCalories;
        }

        private void UpdateCaloriesForDietPlan(int dietPlanId, int totalCalories)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to update the calories for the specified diet plan
                    string updateQuery = "UPDATE diet_plan SET calories = @Calories WHERE diet_plan_id = @DietPlanId";

                    // Create a SqlCommand object with the update query and connection
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters for the calories and diet plan ID
                        updateCommand.Parameters.AddWithValue("@Calories", totalCalories);
                        updateCommand.Parameters.AddWithValue("@DietPlanId", dietPlanId);

                        // Execute the update query
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating calories for diet plan: " + ex.Message);
            }
        }

        private int CalculateMealCalories(int protein, int carbs, int fat, int portion)
        {
            // Calculate calories from each macronutrient
            int proteinCalories = protein * 10;
            int carbCalories = carbs * 10;
            int fatCalories = fat * 21;

            // Calculate total calories for the meal
            int totalCalories = (proteinCalories + carbCalories + fatCalories);

            return totalCalories;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please save your diet plan first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
