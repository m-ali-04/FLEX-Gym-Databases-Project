using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class admin_add_gym : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";

        public admin_add_gym()
        {
            InitializeComponent();
            LoadPendingGyms();
        }

        private void admin_add_gym_Load(object sender, EventArgs e)
        {
            LoadPendingGyms();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int gymOwnerId = int.Parse(textBox1.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE gym_owners SET approval = 1 WHERE gym_owner_id = @OwnerId";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@OwnerId", gymOwnerId);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Approval status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingGyms(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No gym owner found with the specified ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadPendingGyms()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT gym_owners.gym_owner_id, gym.gym_id, gym.num_machines, gym.num_members, gym.price, gym.maintenance_fee,
                                    users.user_name AS owner_name, users.user_contact AS owner_contact, users.user_email AS owner_email
                                    FROM gym
                                    INNER JOIN gym_owners ON gym.gym_id = gym_owners.gym_id
                                    INNER JOIN users ON gym_owners.user_id = users.user_id
                                    WHERE gym_owners.approval = 0";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading pending gyms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
