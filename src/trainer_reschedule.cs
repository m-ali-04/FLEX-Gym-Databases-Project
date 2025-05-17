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
    public partial class trainer_reschedule : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";
        int app_id;
        public trainer_reschedule(int i)
        {
            InitializeComponent();
            app_id = i;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the new schedule from dateTimePicker1
                DateTime newSchedule = dateTimePicker1.Value;

                // Update the appointment schedule in the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to update the appointment schedule
                    string updateQuery = @"UPDATE appointment
                                           SET schedule = @NewSchedule
                                           WHERE app_id = @AppointmentId";

                    // Create a SqlCommand object with the query and connection
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters for new schedule and appointment ID
                        command.Parameters.AddWithValue("@NewSchedule", newSchedule);
                        command.Parameters.AddWithValue("@AppointmentId", app_id);

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment schedule updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No appointment found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
