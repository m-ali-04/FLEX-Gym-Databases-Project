using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO; // Add this namespace for file operations
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml; // Add this namespace for EPPlus

namespace project
{
    
    public partial class member_sign_up : Form
    {
        public member_sign_up()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // Check if any textbox is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the event handler if any textbox is empty
            }

            try
            {
                // Establish connection to the database
                using (SqlConnection conn = new SqlConnection("Data Source = DARKMODE\\SQLEXPRESS; Initial Catalog = FLEXER; Integrated Security = True;"))
                {
                    conn.Open();

                    // Retrieve values from text boxes
                    string name = textBox1.Text;
                    string email = textBox5.Text;
                    string password = textBox6.Text;
                    string contact = textBox2.Text;
                    string address = textBox3.Text;
                    int age = int.Parse(textBox4.Text); // Parse age to int

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

                        // Save generated user ID in UserInfo
                        UserInfo.UserId = userId;
                        UserInfo.UserName = name;

                        // Insert the generated user_id into the members table
                        string memberQuery = "INSERT INTO members (user_id) VALUES (@UserId)";
                        SqlCommand memberCmd = new SqlCommand(memberQuery, conn);
                        memberCmd.Parameters.AddWithValue("@UserId", userId);
                        memberCmd.ExecuteNonQuery();

                        MessageBox.Show("New Member Registered! Generated User ID: " + userId);
                    }

                    

                    // Hide current form and show Form6
                    this.Hide();
                    member_db f6 = new member_db();
                    f6.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            member_login f7 = new member_login();
            f7.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
