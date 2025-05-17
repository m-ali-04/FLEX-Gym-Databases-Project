namespace project
{
    partial class member_db
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_db));
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderColor = Color.DarkGray;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(450, 180);
            button6.Name = "button6";
            button6.Size = new Size(254, 69);
            button6.TabIndex = 6;
            button6.Text = "Account";
            button6.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(227, 339);
            button1.Name = "button1";
            button1.Size = new Size(550, 69);
            button1.TabIndex = 7;
            button1.Text = "CREATE A WORKOUT PLAN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(227, 471);
            button2.Name = "button2";
            button2.Size = new Size(550, 69);
            button2.TabIndex = 8;
            button2.Text = "CREATE A DIET PLAN";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderColor = Color.DarkGray;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(227, 601);
            button3.Name = "button3";
            button3.Size = new Size(550, 64);
            button3.TabIndex = 9;
            button3.Text = "MY PLANS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderColor = Color.DarkGray;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(236, 733);
            button4.Name = "button4";
            button4.Size = new Size(541, 60);
            button4.TabIndex = 10;
            button4.Text = "APPOINTMENTS";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderColor = Color.DarkGray;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1074, 326);
            button5.Name = "button5";
            button5.Size = new Size(565, 106);
            button5.TabIndex = 11;
            button5.Text = "WORKOUT PLAN";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.FlatAppearance.BorderColor = Color.DarkGray;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(1074, 482);
            button7.Name = "button7";
            button7.Size = new Size(565, 106);
            button7.TabIndex = 12;
            button7.Text = "DIET PLAN";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // member_db
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            DoubleBuffered = true;
            Name = "member_db";
            Text = "Form6";
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
    }
}