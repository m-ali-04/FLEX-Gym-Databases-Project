using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class member_active : Form
    {
        private string connectionString = "Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;";

        public member_active()
        {
            InitializeComponent();
            trackBar1.ValueChanged += TrackBar1_ValueChanged;
            trackBar2.ValueChanged += TrackBar2_ValueChanged;
            LoadActivePlans();
        }

        private void LoadActivePlans()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Load active workout plans
                    string workoutQuery = @"SELECT * FROM active_wplans WHERE user_id = @UserId";
                    using (SqlCommand command = new SqlCommand(workoutQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable workoutTable = new DataTable();
                        adapter.Fill(workoutTable);
                        dataGridView1.DataSource = workoutTable;
                    }

                    // Load active diet plans
                    string dietQuery = @"SELECT * FROM active_dplans WHERE user_id = @UserId";
                    using (SqlCommand command = new SqlCommand(dietQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dietTable = new DataTable();
                        adapter.Fill(dietTable);
                        dataGridView2.DataSource = dietTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading active plans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int planId = int.Parse(textBox4.Text);
                int completion = trackBar1.Value;

                // Update the completion in active_wplans
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE active_wplans SET completion = @Completion WHERE plan_id = @PlanId";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Completion", completion);
                        command.Parameters.AddWithValue("@PlanId", planId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Completion updated successfully for workout plan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                LoadActivePlans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int planId = int.Parse(textBox1.Text);
                int completion = trackBar2.Value;

                // Update the completion in active_dplans
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE active_dplans SET completion = @Completion WHERE plan_id = @PlanId";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Completion", completion);
                        command.Parameters.AddWithValue("@PlanId", planId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Completion updated successfully for diet plan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                LoadActivePlans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Handle the ValueChanged event of the TrackBar control
            // You can perform actions based on the slider value here
            int sliderValue = trackBar1.Value;
            // Example: Update a label with the current slider value
            label1.Text = $"{sliderValue}";
        }

        private void TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            // Handle the ValueChanged event of the TrackBar control
            // You can perform actions based on the slider value here
            int sliderValue = trackBar2.Value;
            // Example: Update a label with the current slider value
            label2.Text = $"{sliderValue}";
        }

        private void member_active_Load(object sender, EventArgs e)
        {
            // Your form load event handler code here
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Your label1 click event handler code here
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            // Your trackBar2 scroll event handler code here
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
