namespace project
{
    partial class admin_gym_performance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_gym_performance));
            button2 = new Button();
            dataGridView1 = new DataGridView();
            textBox2 = new TextBox();
            button1 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(800, 887);
            button2.Name = "button2";
            button2.Size = new Size(302, 84);
            button2.TabIndex = 19;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(157, 399);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1588, 266);
            dataGridView1.TabIndex = 18;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(520, 726);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(506, 71);
            textBox2.TabIndex = 17;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1131, 731);
            button1.Name = "button1";
            button1.Size = new Size(303, 80);
            button1.TabIndex = 16;
            button1.Text = "Revoke";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderColor = Color.DarkGray;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(612, 271);
            button6.Name = "button6";
            button6.Size = new Size(303, 71);
            button6.TabIndex = 14;
            button6.Text = "Refresh";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // admin_gym_performance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(button6);
            DoubleBuffered = true;
            Name = "admin_gym_performance";
            Text = "gym_performance";
            Load += admin_gym_performance_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private Button button1;
        private Button button6;
    }
}