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
    public partial class member_login : Form
    {
        public member_login()
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

                                    // Check if the user is a member
                                    string memberQuery = "SELECT user_id FROM members WHERE user_id = @UserId";
                                    using (SqlCommand memberCmd = new SqlCommand(memberQuery, conn))
                                    {
                                        memberCmd.Parameters.AddWithValue("@UserId", userId);

                                        // Execute the query and retrieve the results
                                        using (SqlDataReader memberReader = memberCmd.ExecuteReader())
                                        {
                                            if (memberReader.Read()) // If user is a member
                                            {
                                                // Save user ID in UserInfo
                                                UserInfo.UserId = userId;
                                                UserInfo.Type = "Member";
                                                UserInfo.UserName = username;

                                                MessageBox.Show("Login successful! You are a member.");
                                                memberReader.Close();

                                                // Hide the current form and show Form6
                                                this.Hide();
                                                member_db f = new member_db();
                                                f.Show();
                                            }
                                            else // If user is not a member
                                            {
                                                MessageBox.Show("You are not a member account.");
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




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
