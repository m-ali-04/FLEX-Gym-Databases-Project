namespace project
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            button2 = new Button();
            button5 = new Button();
            button6 = new Button();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.WhiteSmoke;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(769, 405);
            button2.Name = "button2";
            button2.Size = new Size(383, 99);
            button2.TabIndex = 2;
            button2.Text = "Trainer";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.WhiteSmoke;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(248, 725);
            button5.Name = "button5";
            button5.Size = new Size(383, 92);
            button5.TabIndex = 4;
            button5.Text = "Login";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.WhiteSmoke;
            button6.FlatAppearance.BorderColor = Color.DarkGray;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(248, 405);
            button6.Name = "button6";
            button6.Size = new Size(383, 99);
            button6.TabIndex = 1;
            button6.Text = "Member";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(1300, 405);
            button1.Name = "button1";
            button1.Size = new Size(383, 99);
            button1.TabIndex = 3;
            button1.Text = "Gym Owner";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.WhiteSmoke;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(668, 725);
            button3.Name = "button3";
            button3.Size = new Size(383, 92);
            button3.TabIndex = 5;
            button3.Text = "Reports";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.WhiteSmoke;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(1084, 725);
            button4.Name = "button4";
            button4.Size = new Size(383, 92);
            button4.TabIndex = 6;
            button4.Text = "Audit";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button2);
            DoubleBuffered = true;
            MaximumSize = new Size(1920, 1080);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(1918, 1030);
            Name = "Home";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button button5;
        private Button button6;
        private Button button1;
        private Button button3;
        private Button button4;
    }
}
