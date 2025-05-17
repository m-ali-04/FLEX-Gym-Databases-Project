namespace project
{
    partial class admin_db
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_db));
            button6 = new Button();
            button1 = new Button();
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
            button6.Location = new Point(591, 399);
            button6.Name = "button6";
            button6.Size = new Size(722, 86);
            button6.TabIndex = 8;
            button6.Text = "GYM PERFORMANCES";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(591, 710);
            button1.Name = "button1";
            button1.Size = new Size(722, 86);
            button1.TabIndex = 9;
            button1.Text = "GYM REQUESTS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(button6);
            DoubleBuffered = true;
            Name = "admin";
            Text = "admin";
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button1;
    }
}