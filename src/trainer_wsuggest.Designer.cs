namespace project
{
    partial class trainer_wsuggest
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
            dataGridView2 = new DataGridView();
            button1 = new Button();
            textBox4 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 195);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(430, 252);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(51, 103);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(432, 76);
            dataGridView2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(562, 279);
            button1.Name = "button1";
            button1.Size = new Size(158, 64);
            button1.TabIndex = 23;
            button1.Text = "Suggest";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 20F);
            textBox4.Location = new Point(647, 211);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(86, 43);
            textBox4.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(532, 211);
            label2.Name = "label2";
            label2.Size = new Size(109, 37);
            label2.TabIndex = 28;
            label2.Text = "User ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(104, 26);
            label1.Name = "label1";
            label1.Size = new Size(287, 50);
            label1.TabIndex = 29;
            label1.Text = "Plan Suggestion";
            // 
            // trainer_wsuggest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 481);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "trainer_wsuggest";
            Text = "trainer_wsuggest";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button1;
        private TextBox textBox4;
        private Label label2;
        private Label label1;
    }
}