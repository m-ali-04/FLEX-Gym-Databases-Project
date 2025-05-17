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
    public partial class gym_db : Form
    {
        public gym_db()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gym_add_trainer f = new gym_add_trainer();
            f.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            memberreport Memberreport = new memberreport();
            Memberreport.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trainerreport trainerreport = new trainerreport();  
            trainerreport.Show();
        }
    }
}
