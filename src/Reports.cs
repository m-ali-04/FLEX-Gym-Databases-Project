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

    public partial class Reports : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;"; // Replace with your connection string

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT U.user_id, U.user_name, U.user_age, U.user_address, U.user_contact, U.user_email, A.trainer_id, TG.gym_id
FROM users U
JOIN appointment A ON U.user_id = A.user_id
JOIN trainers T ON A.trainer_id = T.trainer_id
JOIN trainer_gym TG ON T.trainer_id = TG.trainer_id
WHERE A.trainer_id = 1;

";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"S
select * from users join active_dplans on users.user_id = active_dplans.user_id join user_gym on users.user_id = user_gym.user_id where gym_id=2 and active_dplans.diet_plan_id = 7
";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
select * from users join active_dplans on users.user_id = active_dplans.user_id join appointment on users.user_id = appointment.user_id where appointment.trainer_id and active_dplans.diet_plan_id = 7  ";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"select * from diet_plan where calories < 500 and goal = 'Weight Loss'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT DP.diet_plan_id, SUM(M.carbs) AS total_carbohydrates
FROM diet_plan DP
LEFT JOIN diet_meal DM ON DP.diet_plan_id = DM.diet_plan_id
LEFT JOIN meal M ON DM.meal_id = M.meal_id
GROUP BY DP.diet_plan_id
HAVING SUM(M.carbs) < 300 OR SUM(M.carbs) IS NULL;

";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT W.workout_id
FROM workout W
LEFT JOIN chosen_exercise CE ON W.workout_id = CE.workout_id
LEFT JOIN exercises E ON CE.exercise_id = E.exerccise_id
LEFT JOIN machines M ON E.machine_id = M.machine_id
WHERE M.machine_name <> 'machine1' OR M.machine_name IS NULL;

";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT dp.diet_plan_id, dp.goal
FROM diet_plan dp
LEFT JOIN diet_meal dm ON dp.diet_plan_id = dm.diet_plan_id
LEFT JOIN meal m ON dm.meal_id = m.meal_id
LEFT JOIN meal_allergen ma ON m.meal_id = ma.meal_id
LEFT JOIN allergens a ON ma.allergen_id = a.allergen_id
WHERE a.allergen <> 'peanuts' OR a.allergen IS NULL;

";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) AS total_members
FROM user_gym ug
JOIN gym_owners go ON ug.gym_id = go.gym_id
WHERE go.gym_owner_id = 1;


";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT gym_id, COUNT(user_id) AS total_users
FROM user_gym
GROUP BY gym_id;

";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView data source
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
