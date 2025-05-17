namespace project
{
    partial class workout_save
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            comboBox3 = new ComboBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 15F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "15", "30", "45", "60", "90", "120", "150" });
            comboBox1.Location = new Point(352, 151);
            comboBox1.MaxDropDownItems = 4;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(148, 36);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(49, 27);
            label1.Name = "label1";
            label1.Size = new Size(322, 37);
            label1.TabIndex = 9;
            label1.Text = "Schedule and Information";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(352, 295);
            label2.Name = "label2";
            label2.Size = new Size(62, 32);
            label2.TabIndex = 10;
            label2.Text = "Goal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(352, 205);
            label3.Name = "label3";
            label3.Size = new Size(110, 32);
            label3.TabIndex = 11;
            label3.Text = "Difficulty";
            label3.Click += label3_Click;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 15F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Weight Loss", "Weight Gain", "Muscle Growth", "Competion", "Stamina" });
            comboBox2.Location = new Point(352, 343);
            comboBox2.MaxDropDownItems = 4;
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(148, 36);
            comboBox2.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F);
            label4.Location = new Point(352, 106);
            label4.Name = "label4";
            label4.Size = new Size(149, 32);
            label4.TabIndex = 14;
            label4.Text = "Duration (m)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F);
            label5.Location = new Point(49, 106);
            label5.Name = "label5";
            label5.Size = new Size(65, 32);
            label5.TabIndex = 15;
            label5.Text = "Days";
            label5.Click += label5_Click;
            // 
            // comboBox3
            // 
            comboBox3.Font = new Font("Segoe UI", 15F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Beginner", "Amatuer", "Moderate", "Professional", "Extreme" });
            comboBox3.Location = new Point(352, 249);
            comboBox3.MaxDropDownItems = 4;
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(148, 36);
            comboBox3.TabIndex = 13;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 15F);
            checkBox1.Location = new Point(49, 164);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(104, 32);
            checkBox1.TabIndex = 16;
            checkBox1.Text = "Monday";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 15F);
            checkBox2.Location = new Point(49, 202);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(102, 32);
            checkBox2.TabIndex = 17;
            checkBox2.Text = "Tuesday";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 15F);
            checkBox3.Location = new Point(49, 240);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(132, 32);
            checkBox3.TabIndex = 18;
            checkBox3.Text = "Wednesday";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Font = new Font("Segoe UI", 15F);
            checkBox4.Location = new Point(49, 278);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(110, 32);
            checkBox4.TabIndex = 19;
            checkBox4.Text = "Thursday";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Font = new Font("Segoe UI", 15F);
            checkBox5.Location = new Point(49, 316);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(85, 32);
            checkBox5.TabIndex = 20;
            checkBox5.Text = "Friday";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Font = new Font("Segoe UI", 15F);
            checkBox6.Location = new Point(48, 354);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(109, 32);
            checkBox6.TabIndex = 21;
            checkBox6.Text = "Saturday";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(191, 419);
            button1.Name = "button1";
            button1.Size = new Size(158, 64);
            button1.TabIndex = 22;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // workout_save
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 520);
            Controls.Add(button1);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "workout_save";
            Text = "workout_save";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private Label label4;
        private Label label5;
        private ComboBox comboBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Button button1;
    }
}