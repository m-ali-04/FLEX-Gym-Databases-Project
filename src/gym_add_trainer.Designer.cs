namespace project
{
    partial class gym_add_trainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gym_add_trainer));
            button5 = new Button();
            textBox5 = new TextBox();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.WhiteSmoke;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(1920, 1080);
            button5.Name = "button5";
            button5.Size = new Size(383, 92);
            button5.TabIndex = 14;
            button5.Text = "Register";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(1039, 749);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(90, 57);
            textBox5.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(819, 752);
            label4.Name = "label4";
            label4.Size = new Size(207, 50);
            label4.TabIndex = 41;
            label4.Text = "Request ID:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(258, 381);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1425, 327);
            dataGridView1.TabIndex = 42;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(1016, 851);
            button2.Name = "button2";
            button2.Size = new Size(444, 85);
            button2.TabIndex = 43;
            button2.Text = "DECLINE";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(509, 851);
            button1.Name = "button1";
            button1.Size = new Size(442, 85);
            button1.TabIndex = 44;
            button1.Text = "ACCEPT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // gym_add_trainer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(button5);
            Controls.Add(textBox5);
            DoubleBuffered = true;
            Name = "gym_add_trainer";
            Text = "add_a_trainer";
            Load += gym_add_trainer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button5;
        private TextBox textBox5;
        private Label label4;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
    }
}