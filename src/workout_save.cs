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
    public partial class workout_save : Form
    {
        int workoutid;
        public workout_save(int id)
        {
            InitializeComponent();
            workoutid = id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the values from the ComboBoxes and CheckBoxes
                string experienceNeeded = comboBox3.SelectedItem.ToString();
                int duration = Convert.ToInt32(comboBox1.SelectedItem);
                string goal = comboBox2.SelectedItem.ToString();
                bool mondayFlag = checkBox1.Checked;
                bool tuesdayFlag = checkBox2.Checked;
                bool wednesdayFlag = checkBox3.Checked;
                bool thursdayFlag = checkBox4.Checked;
                bool fridayFlag = checkBox5.Checked;
                bool saturdayFlag = checkBox6.Checked;

                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;"))
                {
                    conn.Open();

                    // Define the SQL INSERT query for workout_info table
                    string query = "INSERT INTO workout_info (workout_id, experience_needed, goal, duration, monday_flag, tuesday_flag, wednesday_flag, thursday_flag, friday_flag, saturday_flag) " +
                                   "VALUES (@Workoutid, @ExperienceNeeded, @Goal, @Duration, @MondayFlag, @TuesdayFlag, @WednesdayFlag, @ThursdayFlag, @FridayFlag, @SaturdayFlag)";

                    // Create SqlCommand with the INSERT query and connection
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@WorkoutId", workoutid);
                        command.Parameters.AddWithValue("@ExperienceNeeded", experienceNeeded);
                        command.Parameters.AddWithValue("@Goal", goal);
                        command.Parameters.AddWithValue("@Duration", duration);
                        command.Parameters.AddWithValue("@MondayFlag", mondayFlag);
                        command.Parameters.AddWithValue("@TuesdayFlag", tuesdayFlag);
                        command.Parameters.AddWithValue("@WednesdayFlag", wednesdayFlag);
                        command.Parameters.AddWithValue("@ThursdayFlag", thursdayFlag);
                        command.Parameters.AddWithValue("@FridayFlag", fridayFlag);
                        command.Parameters.AddWithValue("@SaturdayFlag", saturdayFlag);

                        // Execute the query
                        command.ExecuteNonQuery();

                        MessageBox.Show("Workout information saved successfully!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
