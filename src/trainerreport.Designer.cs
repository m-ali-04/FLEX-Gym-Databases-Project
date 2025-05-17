namespace project
{
    partial class trainerreport
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
            dataGridView1 = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(80, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(654, 272);
            dataGridView1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(306, 48);
            button2.Name = "button2";
            button2.Size = new Size(211, 56);
            button2.TabIndex = 17;
            button2.Text = "Ratings";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(80, 48);
            button1.Name = "button1";
            button1.Size = new Size(220, 56);
            button1.TabIndex = 18;
            button1.Text = "Experience";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gray;
            button3.FlatAppearance.BorderColor = Color.DarkGray;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(523, 48);
            button3.Name = "button3";
            button3.Size = new Size(211, 56);
            button3.TabIndex = 19;
            button3.Text = "Clients";
            button3.UseVisualStyleBackColor = false;
            // 
            // trainerreport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Name = "trainerreport";
            Text = "trainerreport";
            Load += trainerreport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button2;
        private Button button1;
        private Button button3;
    }
}