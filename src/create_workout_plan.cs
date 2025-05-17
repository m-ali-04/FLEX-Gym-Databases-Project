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
    public partial class create_workout_plan : Form
    {
        int currentW = 0;
        bool saved = false;

        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";
        public create_workout_plan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Display a warning message
            DialogResult result = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            // Check the user's response
            if (result == DialogResult.OK)
            {
                // User clicked OK, so delete the data
                DeleteWorkoutData();
            }
        }

        private void DeleteWorkoutData()
        {
            if (!saved)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Delete entries from chosen_exercise table for the current workout ID
                        string deleteChosenExerciseQuery = "DELETE FROM chosen_exercise WHERE workout_id = @WorkoutId";
                        using (SqlCommand cmd = new SqlCommand(deleteChosenExerciseQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@WorkoutId", currentW);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete entry from workout table for the current workout ID
                        string deleteWorkoutQuery = "DELETE FROM workout WHERE workout_id = @WorkoutId";
                        using (SqlCommand cmd = new SqlCommand(deleteWorkoutQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@WorkoutId", currentW);
                            cmd.ExecuteNonQuery();
                        }

                        // Clear the current workout ID
                        currentW = 0;

                        // Show a message indicating successful deletion
                        MessageBox.Show("Workout data deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting workout data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }



        private void create_workout_plan_Load(object sender, EventArgs e)
        {
            // Call the method to load data into the DataGridView when the form is loaded
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define your SQL query to select rows from the "exercises" table
                    string query = "SELECT * FROM exercises";

                    // Check if textBox1 is not empty, add a WHERE clause to filter exercises by target muscle
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        query += " WHERE target_muscle = @TargetMuscle";
                    }

                    // Check if textBox2 is not empty, add a WHERE clause to filter exercises by exercise ID
                    if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        // If there is already a WHERE clause, add AND, otherwise add WHERE
                        if (query.Contains("WHERE"))
                        {
                            query += " AND exerccise_id = @ExerciseId";
                        }
                        else
                        {
                            query += " WHERE exerccise_id = @ExerciseId";
                        }
                    }

                    // Check if textBox3 is not empty, add a WHERE clause to filter exercises by machine ID
                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        // If there is already a WHERE clause, add AND, otherwise add WHERE
                        if (query.Contains("WHERE"))
                        {
                            query += " AND machine_id = @MachineId";
                        }
                        else
                        {
                            query += " WHERE machine_id = @MachineId";
                        }
                    }

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for filtering
                        if (!string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            command.Parameters.AddWithValue("@TargetMuscle", textBox1.Text);
                        }
                        if (!string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            command.Parameters.AddWithValue("@ExerciseId", int.Parse(textBox2.Text));
                        }
                        if (!string.IsNullOrWhiteSpace(textBox3.Text))
                        {
                            command.Parameters.AddWithValue("@MachineId", int.Parse(textBox3.Text));
                        }

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

                    // Load data into dataGridView2 only if currentW is not 0
                    if (currentW != 0)
                    {
                        // Define your SQL query to select rows from the "chosen_exercises" table where workout_id matches the generated workout ID
                        string chosenExercisesQuery = "SELECT * FROM chosen_exercise WHERE workout_id = @WorkoutId;";

                        // Create a SqlCommand object with the query and connection
                        using (SqlCommand command = new SqlCommand(chosenExercisesQuery, connection))
                        {
                            // Add parameter for filtering by workout ID
                            command.Parameters.AddWithValue("@WorkoutId", currentW);

                            // Create a DataTable to hold the results of the query
                            DataTable chosenExercisesTable = new DataTable();

                            // Create a SqlDataAdapter to fill the DataTable with the results of the query
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                // Fill the DataTable
                                adapter.Fill(chosenExercisesTable);
                            }

                            // Bind the DataTable to dataGridView2
                            dataGridView2.DataSource = chosenExercisesTable;
                        }
                    }

                    query = @"
                        SELECT w.workout_id,
                        wi.goal,
                        wi.experience_needed,
                        wi.duration,
                        COUNT(ce.chosen_exercise_id) AS num_chosen_exercises
                        FROM workout w 
                        INNER JOIN workout_info wi ON w.workout_id = wi.workout_id
                        LEFT JOIN chosen_exercise ce ON w.workout_id = ce.workout_id
                        where w.user_id = @UserId 
                        GROUP BY w.workout_id, wi.goal, wi.experience_needed, wi.duration;
                        ";


                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter for filtering by user ID
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        // Create a DataTable to hold the results of the query
                        DataTable dataTableu = new DataTable();

                        // Create a SqlDataAdapter to fill the DataTable with the results of the query
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable
                            adapter.Fill(dataTableu);
                        }

                        // Bind the DataTable to dataGridView3
                        dataGridView3.DataSource = dataTableu;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse the text from textBox4 to an integer
                if (int.TryParse(textBox4.Text, out int exercise_id))
                {
                    // Create an instance of the modify_workout form with the workoutId parameter
                    m_workout f = new m_workout(exercise_id, currentW);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Exercise ID. Please enter a valid integer value.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                {
                    conn.Open();

                    // Retrieve user ID and type from UserInfo
                    int userId = UserInfo.UserId;
                    string type = UserInfo.Type; // Assuming UserInfo has a Type property

                    // Define the SQL INSERT query for workout table with OUTPUT clause to retrieve the generated ID
                    string workoutQuery = "INSERT INTO workout (user_id, created_by) OUTPUT INSERTED.workout_id VALUES (@UserId, @CreatedBy)";

                    // Create SqlCommand with the INSERT query for workout table and connection
                    using (SqlCommand workoutCmd = new SqlCommand(workoutQuery, conn))
                    {
                        // Add parameters to the query
                        workoutCmd.Parameters.AddWithValue("@UserId", userId);
                        workoutCmd.Parameters.AddWithValue("@CreatedBy", type);


                        // Execute the query and retrieve the generated ID
                        int generatedWorkoutId = Convert.ToInt32(workoutCmd.ExecuteScalar());

                        currentW = generatedWorkoutId;

                        // Display the generated ID
                        MessageBox.Show("Workout entry created successfully! Generated Workout ID: " + generatedWorkoutId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            workout_save f = new workout_save(currentW);
            saved = true;
            f.Show();
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void create_workout_plan_Load_1(object sender, EventArgs e)
        {

        }
    }
}
