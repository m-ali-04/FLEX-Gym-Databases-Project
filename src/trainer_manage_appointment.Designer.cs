namespace project
{
    partial class trainer_manage_appointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trainer_manage_appointment));
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(185, 441);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(805, 218);
            dataGridView1.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(508, 730);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(168, 48);
            textBox1.TabIndex = 13;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderColor = Color.DarkGray;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(793, 711);
            button6.Name = "button6";
            button6.Size = new Size(257, 81);
            button6.TabIndex = 14;
            button6.Text = "ACCEPT";
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
            button1.Location = new Point(1117, 711);
            button1.Name = "button1";
            button1.Size = new Size(257, 81);
            button1.TabIndex = 15;
            button1.Text = "CANCEL";
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
            button2.Location = new Point(1445, 711);
            button2.Name = "button2";
            button2.Size = new Size(257, 81);
            button2.TabIndex = 16;
            button2.Text = "DECLINE";
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
            button3.Location = new Point(1048, 906);
            button3.Name = "button3";
            button3.Size = new Size(736, 87);
            button3.TabIndex = 18;
            button3.Text = "RESCHEDULE APOINTMENT";
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
            button4.Location = new Point(185, 895);
            button4.Name = "button4";
            button4.Size = new Size(259, 84);
            button4.TabIndex = 17;
            button4.Text = "BACK";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(996, 441);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(776, 218);
            dataGridView2.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(185, 392);
            label1.Name = "label1";
            label1.Size = new Size(235, 37);
            label1.TabIndex = 39;
            label1.Text = "Pending Approval:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(996, 392);
            label3.Name = "label3";
            label3.Size = new Size(321, 37);
            label3.TabIndex = 38;
            label3.Text = "Scheduled Appointments:\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(209, 735);
            label2.Name = "label2";
            label2.Size = new Size(213, 37);
            label2.TabIndex = 40;
            label2.Text = "Appointment ID:";
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderColor = Color.DarkGray;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(1626, 623);
            button5.Name = "button5";
            button5.Size = new Size(146, 36);
            button5.TabIndex = 41;
            button5.Text = "REFRESH";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // trainer_manage_appointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "trainer_manage_appointment";
            Text = "manage_appointment";
            Load += trainer_manage_appointment_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Button button6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView2;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button button5;
    }
}