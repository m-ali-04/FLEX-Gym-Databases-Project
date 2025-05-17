namespace project
{
    partial class member_sign_up
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_sign_up));
            textBox1 = new TextBox();
            button5 = new Button();
            linkLabel1 = new LinkLabel();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(479, 379);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(415, 34);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button5
            // 
            button5.BackColor = Color.WhiteSmoke;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(872, 781);
            button5.Name = "button5";
            button5.Size = new Size(200, 58);
            button5.TabIndex = 11;
            button5.Text = " Sign Up !";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(1017, 263);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(101, 45);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "         ";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(1043, 607);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(415, 34);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(1043, 483);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(415, 77);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(1043, 379);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(415, 34);
            textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(479, 503);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(415, 34);
            textBox5.TabIndex = 7;
            textBox5.TextChanged += textBox5_TextChanged_1;
            // 
            // textBox6
            // 
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(479, 607);
            textBox6.Name = "textBox6";
            textBox6.PasswordChar = '*';
            textBox6.Size = new Size(415, 34);
            textBox6.TabIndex = 9;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(linkLabel1);
            Controls.Add(button5);
            Controls.Add(textBox1);
            DoubleBuffered = true;
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button5;
        private LinkLabel linkLabel1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
    }
}