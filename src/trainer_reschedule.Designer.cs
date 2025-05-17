namespace project
{
    partial class trainer_reschedule
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
            dateTimePicker1 = new DateTimePicker();
            button6 = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(44, 29);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderColor = Color.DarkGray;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(44, 58);
            button6.Name = "button6";
            button6.Size = new Size(200, 65);
            button6.TabIndex = 15;
            button6.Text = "CONFIRM";
            button6.UseVisualStyleBackColor = false;
            button6.Click += this.button6_Click;
            // 
            // trainer_reschedule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 135);
            Controls.Add(button6);
            Controls.Add(dateTimePicker1);
            Name = "trainer_reschedule";
            Text = "member_request";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button button6;
    }
}