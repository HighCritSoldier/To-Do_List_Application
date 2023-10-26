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
            AllBtn = new Button();
            CompletedBtn = new Button();
            UncompletedBtn = new Button();
            HighPriorityBtn = new Button();
            MediumPriorityBtn = new Button();
            LowPriorityBtn = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel4 = new Panel();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            TodayBtn = new Button();
            TomorrowBtn = new Button();
            PastDueBtn = new Button();
            ThisWeekBtn = new Button();
            panel5 = new Panel();
            label3 = new Label();
            CategoryAddTxtBox = new TextBox();
            CategoryListBox = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            CategoryFilterBtn = new Button();
            DeleteCategoryBtn = new Button();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            RemoveCategoryFilterBtn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ToDoListView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            ToDoListView.AllowUserToResizeColumns = false;
            ToDoListView.AllowUserToResizeRows = false;
            ToDoListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ToDoListView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ToDoListView.BackgroundColor = Color.FromArgb(32, 32, 32);
            ToDoListView.BorderStyle = BorderStyle.None;
            ToDoListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            ToDoListView.DefaultCellStyle = dataGridViewCellStyle1;
            ToDoListView.EditMode = DataGridViewEditMode.EditOnKeystroke;
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
            flowLayoutPanel1.Controls.Add(AllBtn);
            flowLayoutPanel1.Controls.Add(CompletedBtn);
            flowLayoutPanel1.Controls.Add(UncompletedBtn);
            flowLayoutPanel1.Controls.Add(HighPriorityBtn);
            flowLayoutPanel1.Controls.Add(MediumPriorityBtn);
            flowLayoutPanel1.Controls.Add(LowPriorityBtn);
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
            // AllBtn
            // 
            AllBtn.BackColor = Color.LightGray;
            AllBtn.Location = new Point(252, 5);
            AllBtn.Margin = new Padding(30, 5, 3, 5);
            AllBtn.Name = "AllBtn";
            AllBtn.Size = new Size(50, 35);
            AllBtn.TabIndex = 0;
            AllBtn.Text = "All";
            AllBtn.UseVisualStyleBackColor = false;
            AllBtn.Click += AllBtn_Click;
            // 
            // CompletedBtn
            // 
            CompletedBtn.Location = new Point(308, 5);
            CompletedBtn.Margin = new Padding(3, 5, 3, 5);
            CompletedBtn.Name = "CompletedBtn";
            CompletedBtn.Size = new Size(100, 35);
            CompletedBtn.TabIndex = 1;
            CompletedBtn.Text = "Completed";
            CompletedBtn.UseVisualStyleBackColor = true;
            CompletedBtn.Click += CompletedBtn_Click;
            // 
            // UncompletedBtn
            // 
            UncompletedBtn.Location = new Point(414, 5);
            UncompletedBtn.Margin = new Padding(3, 5, 3, 5);
            UncompletedBtn.Name = "UncompletedBtn";
            UncompletedBtn.Size = new Size(100, 35);
            UncompletedBtn.TabIndex = 2;
            UncompletedBtn.Text = "Uncompleted";
            UncompletedBtn.UseVisualStyleBackColor = true;
            UncompletedBtn.Click += UncompletedBtn_Click;
            // 
            // HighPriorityBtn
            // 
            HighPriorityBtn.Location = new Point(547, 5);
            HighPriorityBtn.Margin = new Padding(30, 5, 3, 5);
            HighPriorityBtn.Name = "HighPriorityBtn";
            HighPriorityBtn.Size = new Size(100, 35);
            HighPriorityBtn.TabIndex = 4;
            HighPriorityBtn.Text = "High Priority";
            HighPriorityBtn.UseVisualStyleBackColor = true;
            HighPriorityBtn.Click += HighPriorityBtn_Click;
            // 
            // MediumPriorityBtn
            // 
            MediumPriorityBtn.Location = new Point(653, 5);
            MediumPriorityBtn.Margin = new Padding(3, 5, 3, 5);
            MediumPriorityBtn.Name = "MediumPriorityBtn";
            MediumPriorityBtn.Size = new Size(110, 35);
            MediumPriorityBtn.TabIndex = 5;
            MediumPriorityBtn.Text = "Medium Priority";
            MediumPriorityBtn.UseVisualStyleBackColor = true;
            MediumPriorityBtn.Click += MediumPriorityBtn_Click;
            // 
            // LowPriorityBtn
            // 
            LowPriorityBtn.Location = new Point(769, 5);
            LowPriorityBtn.Margin = new Padding(3, 5, 3, 5);
            LowPriorityBtn.Name = "LowPriorityBtn";
            LowPriorityBtn.Size = new Size(100, 35);
            LowPriorityBtn.TabIndex = 6;
            LowPriorityBtn.Text = "Low Priority";
            LowPriorityBtn.UseVisualStyleBackColor = true;
            LowPriorityBtn.Click += LowPriorityBtn_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(panel4);
            flowLayoutPanel2.Controls.Add(tableLayoutPanel2);
            flowLayoutPanel2.Controls.Add(panel5);
            flowLayoutPanel2.Controls.Add(CategoryAddTxtBox);
            flowLayoutPanel2.Controls.Add(CategoryListBox);
            flowLayoutPanel2.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel2.Controls.Add(RemoveCategoryFilterBtn);
            flowLayoutPanel2.Location = new Point(10, 60);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(284, 539);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(64, 64, 64);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(281, 32);
            panel4.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 32);
            label2.TabIndex = 0;
            label2.Text = "Dates:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(TodayBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(TomorrowBtn, 1, 0);
            tableLayoutPanel2.Controls.Add(PastDueBtn, 1, 1);
            tableLayoutPanel2.Controls.Add(ThisWeekBtn, 0, 1);
            tableLayoutPanel2.Location = new Point(3, 41);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(281, 100);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // TodayBtn
            // 
            TodayBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TodayBtn.Location = new Point(3, 3);
            TodayBtn.Name = "TodayBtn";
            TodayBtn.Size = new Size(134, 40);
            TodayBtn.TabIndex = 0;
            TodayBtn.Text = "Today";
            TodayBtn.TextAlign = ContentAlignment.MiddleLeft;
            TodayBtn.UseVisualStyleBackColor = true;
            TodayBtn.Click += TodayBtn_Click;
            // 
            // TomorrowBtn
            // 
            TomorrowBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TomorrowBtn.Location = new Point(143, 3);
            TomorrowBtn.Name = "TomorrowBtn";
            TomorrowBtn.Size = new Size(135, 40);
            TomorrowBtn.TabIndex = 1;
            TomorrowBtn.Text = "Tomorrow";
            TomorrowBtn.TextAlign = ContentAlignment.MiddleLeft;
            TomorrowBtn.UseVisualStyleBackColor = true;
            TomorrowBtn.Click += TomorrowBtn_Click;
            // 
            // PastDueBtn
            // 
            PastDueBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PastDueBtn.Location = new Point(143, 53);
            PastDueBtn.Name = "PastDueBtn";
            PastDueBtn.Size = new Size(135, 40);
            PastDueBtn.TabIndex = 2;
            PastDueBtn.Text = "Past Due";
            PastDueBtn.TextAlign = ContentAlignment.MiddleLeft;
            PastDueBtn.UseVisualStyleBackColor = true;
            PastDueBtn.Click += PastDueBtn_Click;
            // 
            // ThisWeekBtn
            // 
            ThisWeekBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ThisWeekBtn.Location = new Point(3, 53);
            ThisWeekBtn.Name = "ThisWeekBtn";
            ThisWeekBtn.Size = new Size(134, 40);
            ThisWeekBtn.TabIndex = 4;
            ThisWeekBtn.Text = "Week";
            ThisWeekBtn.TextAlign = ContentAlignment.MiddleLeft;
            ThisWeekBtn.UseVisualStyleBackColor = true;
            ThisWeekBtn.Click += ThisWeekBtn_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(64, 64, 64);
            panel5.Controls.Add(label3);
            panel5.Location = new Point(3, 147);
            panel5.Name = "panel5";
            panel5.Size = new Size(281, 32);
            panel5.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(132, 32);
            label3.TabIndex = 0;
            label3.Text = "Categories:";
            // 
            // CategoryAddTxtBox
            // 
            CategoryAddTxtBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CategoryAddTxtBox.Location = new Point(3, 185);
            CategoryAddTxtBox.Name = "CategoryAddTxtBox";
            CategoryAddTxtBox.PlaceholderText = "Enter Category (Hit Enter to Add)";
            CategoryAddTxtBox.Size = new Size(281, 29);
            CategoryAddTxtBox.TabIndex = 8;
            CategoryAddTxtBox.KeyPress += CategoryAddTxtBox_KeyPress;
            // 
            // CategoryListBox
            // 
            CategoryListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CategoryListBox.FormattingEnabled = true;
            CategoryListBox.ItemHeight = 21;
            CategoryListBox.Location = new Point(3, 220);
            CategoryListBox.Name = "CategoryListBox";
            CategoryListBox.Size = new Size(281, 109);
            CategoryListBox.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(CategoryFilterBtn, 0, 0);
            tableLayoutPanel1.Controls.Add(DeleteCategoryBtn, 1, 0);
            tableLayoutPanel1.Location = new Point(3, 335);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(281, 60);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // CategoryFilterBtn
            // 
            CategoryFilterBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CategoryFilterBtn.Location = new Point(3, 3);
            CategoryFilterBtn.Name = "CategoryFilterBtn";
            CategoryFilterBtn.Size = new Size(134, 52);
            CategoryFilterBtn.TabIndex = 0;
            CategoryFilterBtn.Text = "Filter By Category";
            CategoryFilterBtn.UseVisualStyleBackColor = true;
            CategoryFilterBtn.Click += CategoryFilterBtn_Click;
            // 
            // DeleteCategoryBtn
            // 
            DeleteCategoryBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteCategoryBtn.Location = new Point(143, 3);
            DeleteCategoryBtn.Name = "DeleteCategoryBtn";
            DeleteCategoryBtn.Size = new Size(134, 52);
            DeleteCategoryBtn.TabIndex = 1;
            DeleteCategoryBtn.Text = "Delete Category";
            DeleteCategoryBtn.UseVisualStyleBackColor = true;
            DeleteCategoryBtn.Click += DeleteCategoryBtn_Click;
            // 
            // RemoveCategoryFilterBtn
            // 
            RemoveCategoryFilterBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            RemoveCategoryFilterBtn.Location = new Point(3, 401);
            RemoveCategoryFilterBtn.Name = "RemoveCategoryFilterBtn";
            RemoveCategoryFilterBtn.Size = new Size(281, 52);
            RemoveCategoryFilterBtn.TabIndex = 12;
            RemoveCategoryFilterBtn.Text = "Remove Category Filter";
            RemoveCategoryFilterBtn.UseVisualStyleBackColor = true;
            RemoveCategoryFilterBtn.Click += RemoveCategoryFilterBtn_Click;
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
            flowLayoutPanel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
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
        private Button AllBtn;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button TodayBtn;
        private Button TomorrowBtn;
        private Button PastDueBtn;
        private Button CompletedBtn;
        private Button UncompletedBtn;
        private Button ThisWeekBtn;
        private Button AddItemBtn;
        private Button HighPriorityBtn;
        private Button MediumPriorityBtn;
        private Button LowPriorityBtn;
        private Button DeleteItemBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private Label label3;
        private TextBox CategoryAddTxtBox;
        private ListBox CategoryListBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button CategoryFilterBtn;
        private TableLayoutPanel tableLayoutPanel2;
        private Button DeleteCategoryBtn;
        private Button RemoveCategoryFilterBtn;
    }
}