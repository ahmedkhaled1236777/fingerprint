namespace fingerprint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listView1 = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(424, 87);
            button1.Name = "button1";
            button1.Size = new Size(171, 35);
            button1.TabIndex = 0;
            button1.Text = "عرض";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.BackColor = SystemColors.InactiveCaption;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader3, columnHeader1 });
            listView1.GridLines = true;
            listView1.Location = new Point(12, 138);
            listView1.Name = "listView1";
            listView1.RightToLeft = RightToLeft.Yes;
            listView1.RightToLeftLayout = true;
            listView1.Size = new Size(776, 300);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "الاسم";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 320;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "التاريخ والوقت";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 320;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "الحاله";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 130;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(508, 41);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(37, 41);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(588, 9);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 4;
            label1.Text = "التاريخ من";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 9);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 5;
            label2.Text = "التاريخ الى";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(203, 87);
            button2.Name = "button2";
            button2.Size = new Size(174, 35);
            button2.TabIndex = 6;
            button2.Text = "تحميل";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(listView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "تحميل العمال";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListView listView1;
        private DateTimePicker dateTimePicker1;
        private ColumnHeader columnHeader2;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader1;
        private Button button2;
    }
}
