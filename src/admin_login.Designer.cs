namespace project
{
    partial class admin_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_login));
            button5 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.WhiteSmoke;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(879, 718);
            button5.Name = "button5";
            button5.Size = new Size(191, 46);
            button5.TabIndex = 15;
            button5.Text = "Login !";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(756, 581);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(415, 34);
            textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Times New Roman", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(756, 460);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(415, 34);
            textBox1.TabIndex = 13;
            // 
            // admin_login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            DoubleBuffered = true;
            Name = "admin_login";
            Text = "Form5";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}