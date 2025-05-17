using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class member_db : Form
    {
        public member_db()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            create_diet_plan f = new create_diet_plan();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            member_active f = new member_active();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            workout_myplans f = new workout_myplans();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            diet_plan f = new diet_plan();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            create_workout_plan f = new create_workout_plan();
            f.Show();
            MessageBox.Show(UserInfo.UserId.ToString() + UserInfo.UserName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            member_booking f = new member_booking();    
            f.Show();
        }
    }
}
