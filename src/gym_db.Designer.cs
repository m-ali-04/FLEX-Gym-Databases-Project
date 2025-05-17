namespace project
{
    partial class gym_db
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gym_db));
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            button6.Location = new Point(332, 352);
            button6.Name = "button6";
            button6.Size = new Size(415, 72);
            button6.TabIndex = 14;
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
            button1.Location = new Point(1025, 319);
            button1.Name = "button1";
            button1.Size = new Size(444, 86);
            button1.TabIndex = 15;
            button1.Text = "MEMBER REPORTS";
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
            button2.Location = new Point(1025, 477);
            button2.Name = "button2";
            button2.Size = new Size(444, 86);
            button2.TabIndex = 16;
            button2.Text = "TRAINER REPORTS";
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
            button3.Location = new Point(1025, 633);
            button3.Name = "button3";
            button3.Size = new Size(444, 86);
            button3.TabIndex = 17;
            button3.Text = "ADD A TRAINER";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // gym_db
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            DoubleBuffered = true;
            Name = "gym_db";
            Text = "gym_signup";
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}