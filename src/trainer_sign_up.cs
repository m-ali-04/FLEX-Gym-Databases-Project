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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class trainer_sign_up : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";
        public trainer_sign_up()
        {
            InitializeComponent();
            Load1();
        }

        private void trainer_sign_up_Load(object sender, EventArgs e)
        {
            Load1();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
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
                return;
            }

            // Retrieve data from textboxes
            string name = textBox1.Text;
            int age = int.Parse(textBox6.Text);
            string address = textBox5.Text;
            string contact = textBox4.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string qualification = textBox9.Text;
            int experience = int.Parse(textBox8.Text);
            string specialty = textBox7.Text;
            int gymLocationId = int.Parse(textBox10.Text);


            // Insert data into tables
            int userId = InsertUser(name, age, address, contact, email, password);
            int trainerId = InsertTrainer(userId);
            InsertTrainerInfo(trainerId, qualification, experience, specialty);
            int gymId = FindGymId(gymLocationId);
            InsertTrainerGym(trainerId, gymId);


            MessageBox.Show("Your Request has been forwarded to the gym owner.");

            this.Close();
        }

        private int InsertUser(string name, int age, string address, string contact, string email, string password)
        {
            int userId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = @"
                INSERT INTO users (user_name, user_age, user_address, user_contact, user_email, user_password)
                VALUES (@Name, @Age, @Address, @Contact, @Email, @Password);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(insertQuery, conn);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Contact", contact);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    userId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return userId;
        }

        private int InsertTrainer(int userId)
        {
            int trainerId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO trainers (user_id) VALUES (@UserId); SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(insertQuery, conn);
                    command.Parameters.AddWithValue("@UserId", userId);

                    trainerId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return trainerId;
        }

        private void InsertTrainerInfo(int trainerId, string qualification, int experience, string specialty)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = @"
                INSERT INTO trainer_info (trainer_id, rating, qualification, experience, specialty, approval)
                VALUES (@TrainerId, NULL, @Qualification, @Experience, @Specialty, 0);";

                    SqlCommand command = new SqlCommand(insertQuery, conn);
                    command.Parameters.AddWithValue("@TrainerId", trainerId);
                    command.Parameters.AddWithValue("@Qualification", qualification);
                    command.Parameters.AddWithValue("@Experience", experience);
                    command.Parameters.AddWithValue("@Specialty", specialty);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting trainer info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int FindGymId(int gymLocationId)
        {
            int gymId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string selectQuery = "SELECT gym_id FROM gym_locations WHERE loc_id = @LocationId";
                    SqlCommand command = new SqlCommand(selectQuery, conn);
                    command.Parameters.AddWithValue("@LocationId", gymLocationId);

                    gymId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while finding gym ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return gymId;
        }

        private void InsertTrainerGym(int trainerId, int gymId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO trainer_gym (trainer_id, gym_id) VALUES (@TrainerId, @GymId);";
                    SqlCommand command = new SqlCommand(insertQuery, conn);
                    command.Parameters.AddWithValue("@TrainerId", trainerId);
                    command.Parameters.AddWithValue("@GymId", gymId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting trainer gym: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            trainer_login tl = new trainer_login();
            tl.Show();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Load1()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT loc_id, gym_id, loc FROM gym_locations";

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Create a SqlDataAdapter to fill the DataTable with the results of the query
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Fill the DataTable
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to dataGridView1
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading gym locations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
