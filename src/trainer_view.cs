using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace project
{
    public partial class trainer_view : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";

        public trainer_view()
        {
            InitializeComponent();
            LoadFeedback();
            LoadTrainerRating();
            dataGridView1.Columns["comment"].Width = 500;
            UpdateTrainerRating();
        }

        private void trainer_view_Load(object sender, EventArgs e)
        {
            LoadFeedback();
            LoadTrainerRating();
        }

        private void LoadFeedback()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT feedback, comment
                                     FROM user_feedback
                                     WHERE trainer_id = (SELECT trainer_id FROM trainers WHERE user_id = @UserId)";

                    DataTable dataTable = new DataTable();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LoadTrainerRating()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT rating
                                     FROM trainer_info
                                     WHERE trainer_id = (SELECT trainer_id FROM trainers WHERE user_id = @UserId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);

                        object rating = command.ExecuteScalar();
                        if (rating != null)
                        {
                            label1.Text = $"{rating.ToString()}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading trainer rating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTrainerRating()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Calculate average feedback
                    string feedbackQuery = @"SELECT AVG(feedback) AS AverageFeedback
                                     FROM user_feedback
                                     WHERE trainer_id = (SELECT trainer_id FROM trainers WHERE user_id = @UserId)";

                    using (SqlCommand feedbackCommand = new SqlCommand(feedbackQuery, connection))
                    {
                        feedbackCommand.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        object averageFeedback = feedbackCommand.ExecuteScalar();

                        // Update trainer rating in trainer_info table
                        if (averageFeedback != null && averageFeedback != DBNull.Value)
                        {
                            decimal averageRating = Convert.ToDecimal(averageFeedback);

                            string updateQuery = @"UPDATE trainer_info
                                           SET rating = @Rating
                                           WHERE trainer_id = (SELECT trainer_id FROM trainers WHERE user_id = @UserId)";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Rating", averageRating);
                                updateCommand.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating trainer rating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

