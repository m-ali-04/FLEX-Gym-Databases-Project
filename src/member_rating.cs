using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class member_rating : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS; Initial Catalog=FLEXER; Integrated Security=True;";

        public member_rating()
        {
            InitializeComponent();
        }

        private void member_rating_Load(object sender, EventArgs e)
        {
            LoadTrainersWithAppointments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int trainerId = int.Parse(textBox1.Text);
                string comment = textBox2.Text;
                int rating = trackBar1.Value / 2;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO user_feedback (user_id, trainer_id, feedback, comment) VALUES (@UserId, @TrainerId, @Feedback, @Comment)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserInfo.UserId);
                        command.Parameters.AddWithValue("@TrainerId", trainerId);
                        command.Parameters.AddWithValue("@Feedback", rating);
                        command.Parameters.AddWithValue("@Comment", comment);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Feedback submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainersWithAppointments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT t.trainer_id, u.user_name
                                     FROM trainers t
                                     INNER JOIN appointment a ON t.trainer_id = a.trainer_id
                                     INNER JOIN users u ON t.user_id = u.user_id
                                     WHERE a.user_id = @UserId";

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
                MessageBox.Show("An error occurred while loading trainers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
