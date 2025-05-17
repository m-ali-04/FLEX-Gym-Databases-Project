namespace project
{
    partial class memberreport
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
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Gray;
            button3.FlatAppearance.BorderColor = Color.DarkGray;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(516, 50);
            button3.Name = "button3";
            button3.Size = new Size(211, 56);
            button3.TabIndex = 23;
            button3.Text = "Diet Plans";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(73, 50);
            button1.Name = "button1";
            button1.Size = new Size(220, 56);
            button1.TabIndex = 22;
            button1.Text = "Appointments";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(299, 50);
            button2.Name = "button2";
            button2.Size = new Size(211, 56);
            button2.TabIndex = 21;
            button2.Text = "Workout Plans";
            button2.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(73, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(654, 272);
            dataGridView1.TabIndex = 20;
            // 
            // memberreport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Name = "memberreport";
            Text = "memberreport";
            Load += memberreport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
    }
}