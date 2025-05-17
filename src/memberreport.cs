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
    public partial class memberreport : Form
    {
        private string connectionString = "Data Source=DARKMODE\\SQLEXPRESS;Initial Catalog=FLEXER;Integrated Security=True;";
        public memberreport()
        {
            InitializeComponent();
            LoadMemberReport();
        }

        private void memberreport_Load(object sender, EventArgs e)
        {
            LoadMemberReport();
        }

        private void LoadMemberReport()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT u.user_id, u.user_name, 
                                        (SELECT COUNT(*) FROM appointment WHERE user_id = u.user_id) AS Appointments,
                                        (SELECT COUNT(*) FROM workout WHERE user_id = u.user_id) AS WorkoutPlans,
                                        (SELECT COUNT(*) FROM diet_plan WHERE user_id = u.user_id) AS DietPlans
                                    FROM users u";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable table = new DataTable();
                    table.Load(reader);

                    dataGridView1.DataSource = table;
                    dataGridView1.Sort(dataGridView1.Columns["Appointments"], ListSortDirection.Descending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortByAppointments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                string query = @"
            SELECT u.user_id, u.user_name, COUNT(wp.workout_id) AS NumOfWorkoutPlans
            FROM users u
            LEFT JOIN workout wp ON u.user_id = wp.user_id
            GROUP BY u.user_id, u.user_name
            ORDER BY NumOfWorkoutPlans DESC;
        ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SortByDietPlans();
        }

        private void SortByAppointments()
        {
            SortUserData("NumAppointments");
        }

        private void SortByWorkoutPlans()
        {
            SortUserData("NumWorkoutPlans");
        }

        private void SortByDietPlans()
        {
            SortUserData("NumDietPlans");
        }

        private void SortUserData(string sortBy)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT u.user_id, u.user_name, 
                                        (SELECT COUNT(*) FROM appointment WHERE user_id = u.user_id) AS NumAppointments,
                                        (SELECT COUNT(*) FROM workout WHERE user_id = u.user_id) AS NumWorkoutPlans,
                                        (SELECT COUNT(*) FROM diet_plan WHERE user_id = u.user_id) AS NumDietPlans
                                    FROM users u
                   
                ORDER BY {sortBy} DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the sorted DataTable to DataGridView
                        dataGridView1.DataSource = dataTable;
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
