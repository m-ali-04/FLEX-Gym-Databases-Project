using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class gym_add_trainer : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";

        public gym_add_trainer()
        {
            InitializeComponent();
            LoadTrainers();
        }

        private void LoadTrainers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT u.user_id, u.user_name, u.user_age, u.user_address, u.user_contact, u.user_email, 
                t.trainer_id, ti.rating, ti.qualification, ti.experience, ti.specialty, g.loc
                FROM users u
                JOIN trainers t ON u.user_id = t.user_id
                JOIN trainer_info ti ON t.trainer_id = ti.trainer_id
                JOIN trainer_gym tg ON t.trainer_id = tg.trainer_id
                JOIN gym_locations g ON tg.gym_id = g.gym_id
                WHERE ti.approval = 0";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading trainers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gym_add_trainer_Load(object sender, EventArgs e)
        {
            LoadTrainers();
        }





        private void button1_Click(object sender, EventArgs e)
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Assuming you have a DataGridView named dataGridView1 to display trainers


            int selectedTrainerId = Convert.ToInt32(textBox5.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE trainer_info SET approval = 1 WHERE trainer_id = @TrainerId";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@TrainerId", selectedTrainerId);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Trainer approval updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTrainers(); // Refresh the DataGridView to reflect the changes
                    }
                    else
                    {
                        MessageBox.Show("Failed to update trainer approval.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            // Assuming you have a DataGridView named dataGridView1 to display trainers

            int selectedTrainerId = Convert.ToInt32(textBox5.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete from trainer_gym table
                    string deleteTrainerGymQuery = "DELETE FROM trainer_gym WHERE trainer_id = @TrainerId";
                    SqlCommand deleteTrainerGymCommand = new SqlCommand(deleteTrainerGymQuery, connection);
                    deleteTrainerGymCommand.Parameters.AddWithValue("@TrainerId", selectedTrainerId);
                    deleteTrainerGymCommand.ExecuteNonQuery();

                    // Delete from trainer_info table
                    string deleteTrainerInfoQuery = "DELETE FROM trainer_info WHERE trainer_id = @TrainerId";
                    SqlCommand deleteTrainerInfoCommand = new SqlCommand(deleteTrainerInfoQuery, connection);
                    deleteTrainerInfoCommand.Parameters.AddWithValue("@TrainerId", selectedTrainerId);
                    deleteTrainerInfoCommand.ExecuteNonQuery();

                    // Delete from trainers table
                    string deleteTrainerQuery = "DELETE FROM trainers WHERE trainer_id = @TrainerId";
                    SqlCommand deleteTrainerCommand = new SqlCommand(deleteTrainerQuery, connection);
                    deleteTrainerCommand.Parameters.AddWithValue("@TrainerId", selectedTrainerId);
                    deleteTrainerCommand.ExecuteNonQuery();

                    // Delete from users table
                    string deleteUserQuery = "DELETE FROM users WHERE user_id = (SELECT user_id FROM trainers WHERE trainer_id = @TrainerId)";
                    SqlCommand deleteUserCommand = new SqlCommand(deleteUserQuery, connection);
                    deleteUserCommand.Parameters.AddWithValue("@TrainerId", selectedTrainerId);
                    deleteUserCommand.ExecuteNonQuery();

                    MessageBox.Show("Trainer and associated records deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTrainers(); // Refresh the DataGridView to reflect the changes
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
