namespace project
{
    partial class admin_add_gym
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin_add_gym));
            dataGridView1 = new DataGridView();
            button6 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(199, 247);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1585, 272);
            dataGridView1.TabIndex = 12;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderColor = Color.DarkGray;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(1134, 684);
            button6.Name = "button6";
            button6.Size = new Size(246, 83);
            button6.TabIndex = 13;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(523, 684);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(506, 71);
            textBox1.TabIndex = 14;
            // 
            // button2
            // 
            button2.BackColor = Color.SeaGreen;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(644, 839);
            button2.Name = "button2";
            button2.Size = new Size(259, 84);
            button2.TabIndex = 15;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // admin_add_gym
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "admin_add_gym";
            Text = "add_gym";
            Load += admin_add_gym_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button6;
        private TextBox textBox1;
        private Button button2;
    }
}