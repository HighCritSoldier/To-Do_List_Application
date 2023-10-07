namespace To_Do_List_Application
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ToDoListView = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            AddItemBtn = new Button();
            DeleteItemBtn = new Button();
            button5 = new Button();
            button9 = new Button();
            button11 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button6 = new Button();
            button7 = new Button();
            button10 = new Button();
            button8 = new Button();
            StatusCheckBox = new DataGridViewCheckBoxColumn();
            NameTxt = new DataGridViewTextBoxColumn();
            DescriptionTxt = new DataGridViewTextBoxColumn();
            DueDateTxt = new DataGridViewTextBoxColumn();
            PriorityCategory = new DataGridViewComboBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ToDoListView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(48, 48, 48);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1462, 50);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(48, 8);
            label1.Name = "label1";
            label1.Size = new Size(184, 32);
            label1.TabIndex = 1;
            label1.Text = "To-Do List App";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 10);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.FromArgb(48, 48, 48);
            panel2.Location = new Point(300, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(5, 540);
            panel2.TabIndex = 1;
            // 
            // ToDoListView
            // 
            ToDoListView.AllowUserToAddRows = false;
            ToDoListView.AllowUserToDeleteRows = false;
            ToDoListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ToDoListView.BackgroundColor = Color.FromArgb(32, 32, 32);
            ToDoListView.BorderStyle = BorderStyle.None;
            ToDoListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ToDoListView.Columns.AddRange(new DataGridViewColumn[] { StatusCheckBox, NameTxt, DescriptionTxt, DueDateTxt, PriorityCategory });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ToDoListView.DefaultCellStyle = dataGridViewCellStyle2;
            ToDoListView.Location = new Point(311, 106);
            ToDoListView.Name = "ToDoListView";
            ToDoListView.RowTemplate.Height = 25;
            ToDoListView.Size = new Size(1139, 494);
            ToDoListView.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.FromArgb(40, 40, 40);
            flowLayoutPanel1.Controls.Add(AddItemBtn);
            flowLayoutPanel1.Controls.Add(DeleteItemBtn);
            flowLayoutPanel1.Controls.Add(button5);
            flowLayoutPanel1.Controls.Add(button9);
            flowLayoutPanel1.Controls.Add(button11);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Location = new Point(311, 60);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1139, 40);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // AddItemBtn
            // 
            AddItemBtn.Image = Properties.Resources.PlusIcon;
            AddItemBtn.ImageAlign = ContentAlignment.MiddleLeft;
            AddItemBtn.Location = new Point(3, 5);
            AddItemBtn.Margin = new Padding(3, 5, 3, 5);
            AddItemBtn.Name = "AddItemBtn";
            AddItemBtn.Size = new Size(100, 35);
            AddItemBtn.TabIndex = 3;
            AddItemBtn.Text = "        Add Item";
            AddItemBtn.UseVisualStyleBackColor = true;
            AddItemBtn.Click += AddItemBtn_Click;
            // 
            // DeleteItemBtn
            // 
            DeleteItemBtn.Image = Properties.Resources.DeleteIcon;
            DeleteItemBtn.ImageAlign = ContentAlignment.MiddleLeft;
            DeleteItemBtn.Location = new Point(109, 5);
            DeleteItemBtn.Margin = new Padding(3, 5, 3, 5);
            DeleteItemBtn.Name = "DeleteItemBtn";
            DeleteItemBtn.Size = new Size(110, 35);
            DeleteItemBtn.TabIndex = 7;
            DeleteItemBtn.Text = "        Delete Item";
            DeleteItemBtn.UseVisualStyleBackColor = true;
            DeleteItemBtn.Click += DeleteItemBtn_Click;
            // 
            // button5
            // 
            button5.Location = new Point(252, 5);
            button5.Margin = new Padding(30, 5, 3, 5);
            button5.Name = "button5";
            button5.Size = new Size(50, 35);
            button5.TabIndex = 0;
            button5.Text = "All";
            button5.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(308, 5);
            button9.Margin = new Padding(3, 5, 3, 5);
            button9.Name = "button9";
            button9.Size = new Size(100, 35);
            button9.TabIndex = 1;
            button9.Text = "Completed";
            button9.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(414, 5);
            button11.Margin = new Padding(3, 5, 3, 5);
            button11.Name = "button11";
            button11.Size = new Size(100, 35);
            button11.TabIndex = 2;
            button11.Text = "Uncompleted";
            button11.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(547, 5);
            button2.Margin = new Padding(30, 5, 3, 5);
            button2.Name = "button2";
            button2.Size = new Size(100, 35);
            button2.TabIndex = 4;
            button2.Text = "High Priority";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(653, 5);
            button3.Margin = new Padding(3, 5, 3, 5);
            button3.Name = "button3";
            button3.Size = new Size(110, 35);
            button3.TabIndex = 5;
            button3.Text = "Medium Priority";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(769, 5);
            button4.Margin = new Padding(3, 5, 3, 5);
            button4.Name = "button4";
            button4.Size = new Size(100, 35);
            button4.TabIndex = 6;
            button4.Text = "Low Priority";
            button4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button6);
            flowLayoutPanel2.Controls.Add(button7);
            flowLayoutPanel2.Controls.Add(button10);
            flowLayoutPanel2.Controls.Add(button8);
            flowLayoutPanel2.Location = new Point(10, 60);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(284, 539);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(3, 3);
            button6.Name = "button6";
            button6.Size = new Size(281, 40);
            button6.TabIndex = 0;
            button6.Text = "Today";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(3, 49);
            button7.Name = "button7";
            button7.Size = new Size(281, 40);
            button7.TabIndex = 1;
            button7.Text = "Tomorrow";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button10.Location = new Point(3, 95);
            button10.Name = "button10";
            button10.Size = new Size(281, 40);
            button10.TabIndex = 4;
            button10.Text = "This Week";
            button10.TextAlign = ContentAlignment.MiddleLeft;
            button10.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(3, 141);
            button8.Name = "button8";
            button8.Size = new Size(281, 40);
            button8.TabIndex = 2;
            button8.Text = "Past Due";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = true;
            // 
            // StatusCheckBox
            // 
            StatusCheckBox.HeaderText = "Status";
            StatusCheckBox.Name = "StatusCheckBox";
            StatusCheckBox.Width = 50;
            // 
            // NameTxt
            // 
            NameTxt.HeaderText = "Name";
            NameTxt.Name = "NameTxt";
            NameTxt.Width = 150;
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.HeaderText = "Description";
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.Width = 300;
            // 
            // DueDateTxt
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            DueDateTxt.DefaultCellStyle = dataGridViewCellStyle1;
            DueDateTxt.HeaderText = "Due Date";
            DueDateTxt.Name = "DueDateTxt";
            // 
            // PriorityCategory
            // 
            PriorityCategory.HeaderText = "Priority";
            PriorityCategory.Items.AddRange(new object[] { "High", "Medium", "Low" });
            PriorityCategory.Name = "PriorityCategory";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1462, 611);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(ToDoListView);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel2);
            Name = "MainForm";
            Text = "To-Do List App";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ToDoListView).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView ToDoListView;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button5;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button11;
        private Button button10;
        private Button AddItemBtn;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button DeleteItemBtn;
        private DataGridViewCheckBoxColumn StatusCheckBox;
        private DataGridViewTextBoxColumn NameTxt;
        private DataGridViewTextBoxColumn DescriptionTxt;
        private DataGridViewTextBoxColumn DueDateTxt;
        private DataGridViewComboBoxColumn PriorityCategory;
    }
}