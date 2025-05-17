using System.Security.AccessControl;

namespace project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInfo.Type = "Trainer";
            trainer_sign_up f3 = new trainer_sign_up();
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserInfo.Type = "Admin";
            admin_login f5 = new admin_login();
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserInfo.Type = "Member";
            member_sign_up f2 = new member_sign_up();
            f2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            UserInfo.Type = "Gym Owner";
            gym_sign_up f4 = new gym_sign_up();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports re = new Reports();
            re.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            audit a = new audit();
            a.Show();
        }
    }
}
