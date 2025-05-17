namespace project
{
    partial class m_workout
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
            button1 = new Button();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(355, 266);
            button1.Name = "button1";
            button1.Size = new Size(260, 63);
            button1.TabIndex = 13;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(613, 55);
            label3.Name = "label3";
            label3.Size = new Size(172, 37);
            label3.TabIndex = 12;
            label3.Text = "Rest Intervals";
            // 
            // comboBox3
            // 
            comboBox3.Font = new Font("Segoe UI", 20F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "10s", "15s", "25s", "45s", "60s", "100s" });
            comboBox3.Location = new Point(801, 52);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 45);
            comboBox3.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(355, 55);
            label2.Name = "label2";
            label2.Size = new Size(65, 37);
            label2.TabIndex = 10;
            label2.Text = "Sets";
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 20F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1 ", "2", "3", "4", "5", "6" });
            comboBox2.Location = new Point(434, 52);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 45);
            comboBox2.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(93, 55);
            label1.Name = "label1";
            label1.Size = new Size(73, 37);
            label1.TabIndex = 8;
            label1.Text = "Reps";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 20F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "3", "6", "10", "12", "15", "20" });
            comboBox1.Location = new Point(172, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 45);
            comboBox1.TabIndex = 7;
            // 
            // m_workout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 361);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox3);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "m_workout";
            Text = "m_workout";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label3;
        private ComboBox comboBox3;
        private Label label2;
        private ComboBox comboBox2;
        private Label label1;
        private ComboBox comboBox1;
    }
}