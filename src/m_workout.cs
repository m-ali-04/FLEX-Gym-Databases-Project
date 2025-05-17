using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class m_workout : Form
    {
        private int exercise_id;
        private int workout_id; // Added field to store the workout_id

        public m_workout(int id, int w)
        {
            InitializeComponent();
            exercise_id = id; // Save the id parameter to a field
            workout_id = w;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected values from the ComboBoxes
                int reps = Convert.ToInt32(comboBox1.SelectedItem);
                int sets = Convert.ToInt32(comboBox2.SelectedItem);
                string rest_intervals = comboBox3.SelectedItem.ToString();

                int chosenExerciseId; // Variable to store the chosen exercise ID generated

                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;"))
                {
                    conn.Open();

                    // Define your SQL INSERT query for the chosen_exercise table
                    string query = "INSERT INTO chosen_exercise (exercise_id, reps, sets, rest_intervals, workout_id) " +
                                   "VALUES (@exercise_id, @reps, @sets, @rest_intervals, @workout_id);" +
                                   "SELECT SCOPE_IDENTITY();"; // Retrieve the generated chosen_exercise_id

                    // Create SqlCommand with the INSERT query and connection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the query to prevent SQL injection
                        cmd.Parameters.AddWithValue("@exercise_id", exercise_id);
                        cmd.Parameters.AddWithValue("@reps", reps);
                        cmd.Parameters.AddWithValue("@sets", sets);
                        cmd.Parameters.AddWithValue("@rest_intervals", rest_intervals);
                        cmd.Parameters.AddWithValue("@workout_id", workout_id);
                        chosenExerciseId = Convert.ToInt32(cmd.ExecuteScalar());
                    }


                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}




