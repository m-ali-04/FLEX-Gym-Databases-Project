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
    public partial class gym_login : Form
    {
        public gym_login()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;"))
                {
                    conn.Open();

                    // Check if the username exists in the users table
                    string userQuery = "SELECT user_id, user_password FROM users WHERE user_name = @Username";
                    using (SqlCommand userCmd = new SqlCommand(userQuery, conn))
                    {
                        userCmd.Parameters.AddWithValue("@Username", username);

                        // Execute the query and retrieve the results
                        using (SqlDataReader reader = userCmd.ExecuteReader())
                        {
                            if (reader.Read()) // If username exists
                            {
                                int userId = reader.GetInt32(0);
                                string storedPassword = reader.GetString(1);

                                if (password == storedPassword) // If password is correct
                                {
                                    // Close the reader before executing the next query
                                    reader.Close();

                                    // Check if the user is a trainer
                                    string gym_ownerQuery = "SELECT user_id FROM gym_owners WHERE user_id = @UserId";
                                    using (SqlCommand gym_ownerCmd = new SqlCommand(gym_ownerQuery, conn))
                                    {
                                        gym_ownerCmd.Parameters.AddWithValue("@UserId", userId);

                                        // Execute the query and retrieve the results
                                        using (SqlDataReader gym_ownerReader = gym_ownerCmd.ExecuteReader())
                                        {
                                            if (gym_ownerReader.Read()) // If user is a gym_owner
                                            {
                                                MessageBox.Show("Login successful! You are an owner.");
                                                gym_ownerReader.Close();

                                                // Hide the current form and show Form6
                                                this.Hide();
                                                gym_db f = new gym_db();
                                                f.Show();
                                            }
                                            else // If user is not a gym_owner
                                            {
                                                MessageBox.Show("You are not an owner account.");
                                            }
                                        }
                                    }
                                }
                                else // If password is incorrect
                                {
                                    MessageBox.Show("Wrong password.");
                                }
                            }
                            else // If username does not exist
                            {
                                MessageBox.Show("Wrong username.");
                            }
                        }
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
