namespace project
{
    partial class member_rating
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(member_rating));
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            trackBar1 = new TrackBar();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(186, 893);
            button2.Name = "button2";
            button2.Size = new Size(254, 85);
            button2.TabIndex = 17;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1548, 719);
            button1.Name = "button1";
            button1.Size = new Size(254, 72);
            button1.TabIndex = 18;
            button1.Text = "Confirm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(186, 387);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(769, 404);
            dataGridView1.TabIndex = 19;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1081, 729);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(370, 45);
            trackBar1.TabIndex = 20;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(1081, 387);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(370, 279);
            textBox2.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1559, 466);
            label4.Name = "label4";
            label4.Size = new Size(186, 50);
            label4.TabIndex = 42;
            label4.Text = "Trainer ID:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1548, 539);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 71);
            textBox1.TabIndex = 41;
            // 
            // member_rating
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(trackBar1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(button2);
            DoubleBuffered = true;
            Name = "member_rating";
            Text = "member_rating";
            Load += member_rating_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private TrackBar trackBar1;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox1;
    }
}