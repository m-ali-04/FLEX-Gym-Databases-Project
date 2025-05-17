namespace project
{
    partial class trainer_view
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
            label4 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(69, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(439, 294);
            dataGridView1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(554, 141);
            label4.Name = "label4";
            label4.Size = new Size(211, 50);
            label4.TabIndex = 43;
            label4.Text = "Your Rating";
            label4.Click += label4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(610, 231);
            label1.Name = "label1";
            label1.Size = new Size(39, 50);
            label1.TabIndex = 44;
            label1.Text = "?";
            // 
            // trainer_view
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Name = "trainer_view";
            Text = "trainer_view";
            Load += trainer_view_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label4;
        private Label label1;
    }
}