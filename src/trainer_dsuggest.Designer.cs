namespace project
{
    partial class trainer_dsuggest
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
            label1 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 15);
            label1.Name = "label1";
            label1.Size = new Size(287, 50);
            label1.TabIndex = 35;
            label1.Text = "Plan Suggestion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(540, 200);
            label2.Name = "label2";
            label2.Size = new Size(109, 37);
            label2.TabIndex = 34;
            label2.Text = "User ID:";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 20F);
            textBox4.Location = new Point(655, 200);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(86, 43);
            textBox4.TabIndex = 33;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(570, 268);
            button1.Name = "button1";
            button1.Size = new Size(158, 64);
            button1.TabIndex = 32;
            button1.Text = "Suggest";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(59, 92);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(432, 76);
            dataGridView2.TabIndex = 31;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 184);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(430, 252);
            dataGridView1.TabIndex = 30;
            // 
            // trainer_dsuggest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox4);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "trainer_dsuggest";
            Text = "trainer_dsuggest";
            Load += trainer_dsuggest_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox4;
        private Button button1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
    }
}