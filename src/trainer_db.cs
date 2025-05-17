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
    public partial class trainer_db : Form
    {
        public trainer_db()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            trainer_manage_appointment f = new trainer_manage_appointment();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            member_progress f = new member_progress();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            create_workout_plan f = new create_workout_plan();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            create_diet_plan f = new create_diet_plan();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trainer_view trainer_View = new trainer_view();
            trainer_View.Show();
        }
    }
}
