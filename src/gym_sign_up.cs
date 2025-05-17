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
    public partial class gym_sign_up : Form
    {
        public gym_sign_up()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            gym_login f = new gym_login();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            gym_db f = new gym_db();
            f.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Check if any textbox is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the event handler if any textbox is empty
            }

            try
            {
                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;"))
                {
                    conn.Open();

                    // Retrieve values from text boxes
                    string name = textBox1.Text;
                    string email = textBox2.Text;
                    string password = textBox3.Text;
                    string contact = textBox5.Text;
                    string address = textBox6.Text;
                    int age = int.Parse(textBox4.Text); // Parse age to int
                    int maintenanceCost = int.Parse(textBox7.Text);
                    int numMachines = int.Parse(textBox8.Text);
                    int activeMembers = int.Parse(textBox9.Text);

                    // Define the SQL INSERT query for users table
                    string userQuery = "INSERT INTO users (user_name, user_age, user_address, user_contact, user_email, user_password) " +
                                       "VALUES (@Name, @Age, @Address, @Contact, @Email, @Password); " +
                                       "SELECT SCOPE_IDENTITY();"; // Retrieve the generated user_id

                    // Create SqlCommand with the INSERT query for users table and connection
                    using (SqlCommand userCmd = new SqlCommand(userQuery, conn))
                    {
                        // Add parameters to the query to prevent SQL injection
                        userCmd.Parameters.AddWithValue("@Name", name);
                        userCmd.Parameters.AddWithValue("@Age", age);
                        userCmd.Parameters.AddWithValue("@Address", address);
                        userCmd.Parameters.AddWithValue("@Contact", contact);
                        userCmd.Parameters.AddWithValue("@Email", email);
                        userCmd.Parameters.AddWithValue("@Password", password);

                        // Execute the query and retrieve the generated user_id
                        int userId = Convert.ToInt32(userCmd.ExecuteScalar());

                        // Define the SQL INSERT query for gym table
                        string gymQuery = "INSERT INTO gym (num_machines, num_members, price, maintenance_fee) " +
                                          "VALUES (@NumMachines, @NumMembers, 0, @MaintenanceFee); " +
                                          "SELECT SCOPE_IDENTITY();"; // Retrieve the generated gym_id

                        // Create SqlCommand with the INSERT query for gym table and connection
                        using (SqlCommand gymCmd = new SqlCommand(gymQuery, conn))
                        {
                            // Add parameters to the query
                            gymCmd.Parameters.AddWithValue("@NumMachines", numMachines);
                            gymCmd.Parameters.AddWithValue("@NumMembers", activeMembers);
                            gymCmd.Parameters.AddWithValue("@MaintenanceFee", maintenanceCost);

                            // Execute the query and retrieve the generated gym_id
                            int gymId = Convert.ToInt32(gymCmd.ExecuteScalar());

                            // Define the SQL INSERT query for gym_owners table
                            string gymOwnerQuery = "INSERT INTO gym_owners (user_id, gym_id, approval) VALUES (@UserId, @GymId, 0);";
                            SqlCommand gymOwnerCmd = new SqlCommand(gymOwnerQuery, conn);
                            gymOwnerCmd.Parameters.AddWithValue("@UserId", userId);
                            gymOwnerCmd.Parameters.AddWithValue("@GymId", gymId);
                            gymOwnerCmd.ExecuteNonQuery();

                            MessageBox.Show("Your request has been sent to the admin for approval.");
                        }
                    }

                    // Hide current form
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            gym_login gym_Login = new gym_login();
            gym_Login.Show();
        }

        private void gym_sign_up_Load(object sender, EventArgs e)
        {

        }
    }
}
