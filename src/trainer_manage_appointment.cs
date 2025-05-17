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
    public partial class trainer_manage_appointment : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";
        public trainer_manage_appointment()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer_db f = new trainer_db();
            f.Show();
        }

        private void trainer_manage_appointment_Load(object sender, EventArgs e)
        {
            // Load appointments with approval 0 into DataGridView1
            LoadPendingAppointments();

            // Load appointments with approval 1 into DataGridView2
            LoadApprovedAppointments();
        }

        private void LoadPendingAppointments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select the trainer ID for the current user from the trainers table
                    string trainerIdQuery = "SELECT trainer_id FROM trainers WHERE user_id = @UserId";

                    // Create a SqlCommand object to execute the trainerIdQuery
                    using (SqlCommand trainerIdCommand = new SqlCommand(trainerIdQuery, connection))
                    {
                        // Add parameter for the user ID
                        trainerIdCommand.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        // Execute the query to get the trainer ID
                        int trainerId = Convert.ToInt32(trainerIdCommand.ExecuteScalar());

                        // Define the SQL query to select pending appointments for the current trainer
                        string query = @"SELECT app_id, user_id, schedule
                         FROM appointment
                         WHERE trainer_id = @TrainerId AND approval = 0";

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
                MessageBox.Show("An error occurred while loading pending appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApprovedAppointments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to select the trainer ID for the current user from the trainers table
                    string trainerIdQuery = "SELECT trainer_id FROM trainers WHERE user_id = @UserId";

                    // Create a SqlCommand object to execute the trainerIdQuery
                    using (SqlCommand trainerIdCommand = new SqlCommand(trainerIdQuery, connection))
                    {
                        // Add parameter for the user ID
                        trainerIdCommand.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        // Execute the query to get the trainer ID
                        int trainerId = Convert.ToInt32(trainerIdCommand.ExecuteScalar());

                        // Define the SQL query to select approved appointments for the current trainer
                        string query = @"SELECT app_id, user_id, schedule
                         FROM appointment
                         WHERE trainer_id = @TrainerId AND approval = 1";

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

                        // Bind the DataTable to dataGridView2
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading approved appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the appointment ID from TextBox1
                int appointmentId = int.Parse(textBox1.Text);

                // Update the approval to 1 in the appointment table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to update the approval
                    string updateQuery = "UPDATE appointment SET approval = 1 WHERE app_id = @AppointmentId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameter for the appointment ID
                        command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display a success message
                            MessageBox.Show("Appointment approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the pending and approved appointments
                            LoadPendingAppointments();
                            LoadApprovedAppointments();
                        }
                        else
                        {
                            // Display a message if no rows were affected (appointment ID not found)
                            MessageBox.Show("Appointment ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
                // Get the appointment ID from TextBox1
                int appointmentId = int.Parse(textBox1.Text);

                // Delete the appointment from the appointment table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to delete the appointment
                    string deleteQuery = "DELETE FROM appointment WHERE app_id = @AppointmentId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Add parameter for the appointment ID
                        command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        // Execute the delete query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display a success message
                            MessageBox.Show("Appointment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the pending and approved appointments
                            LoadPendingAppointments();
                            LoadApprovedAppointments();
                        }
                        else
                        {
                            // Display a message if no rows were affected (appointment ID not found)
                            MessageBox.Show("Appointment ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
                // Get the appointment ID from TextBox1
                int appointmentId = int.Parse(textBox1.Text);

                // Delete the appointment from the appointment table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to delete the appointment
                    string deleteQuery = "DELETE FROM appointment WHERE app_id = @AppointmentId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Add parameter for the appointment ID
                        command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        // Execute the delete query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            // Display a success message
                            MessageBox.Show("Appointment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the pending and approved appointments
                            LoadPendingAppointments();
                            LoadApprovedAppointments();
                        }
                        else
                        {
                            // Display a message if no rows were affected (appointment ID not found)
                            MessageBox.Show("Appointment ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
                // Get the appointment ID from TextBox1
                int appointmentId = int.Parse(textBox1.Text);

                // Create an instance of the trainer_reschedule form and pass the appointment ID as a parameter
                trainer_reschedule trainer_Reschedule = new trainer_reschedule(appointmentId);
                trainer_Reschedule.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadPendingAppointments();
            LoadApprovedAppointments();
        }
    }
}
