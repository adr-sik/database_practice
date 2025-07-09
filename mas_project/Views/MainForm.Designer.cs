namespace mas_project.Views
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            label1 = new Label();
            infoButton = new Button();
            dataGridView1 = new DataGridView();
            slideBindingSource = new BindingSource(components);
            slideBindingSource1 = new BindingSource(components);
            comboBox1 = new ComboBox();
            DevicesTab = new Button();
            PlaygroundsTab = new Button();
            addButton = new Button();
            fromLabel = new Label();
            toLabel = new Label();
            toTextBox = new TextBox();
            fromMonthCalendar = new MonthCalendar();
            toMonthCalendar = new MonthCalendar();
            panel1 = new Panel();
            fromTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slideBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slideBindingSource1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(676, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 23F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(109, 52);
            label1.TabIndex = 1;
            label1.Text = "Offer";
            // 
            // infoButton
            // 
            infoButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            infoButton.Location = new Point(676, 512);
            infoButton.Name = "infoButton";
            infoButton.Size = new Size(94, 29);
            infoButton.TabIndex = 3;
            infoButton.Text = "images";
            infoButton.UseVisualStyleBackColor = true;
            infoButton.Click += button2_ClickAsync;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 127);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(758, 369);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // slideBindingSource
            // 
            slideBindingSource.DataSource = typeof(Models.Slide);
            // 
            // slideBindingSource1
            // 
            slideBindingSource1.DataSource = typeof(Models.Slide);
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Slides", "Swings" });
            comboBox1.Location = new Point(613, 92);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Pick Type";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // DevicesTab
            // 
            DevicesTab.Location = new Point(12, 92);
            DevicesTab.Name = "DevicesTab";
            DevicesTab.Size = new Size(94, 29);
            DevicesTab.TabIndex = 5;
            DevicesTab.Text = "Devices";
            DevicesTab.UseVisualStyleBackColor = true;
            DevicesTab.Click += DevicesTab_Click;
            // 
            // PlaygroundsTab
            // 
            PlaygroundsTab.Location = new Point(112, 92);
            PlaygroundsTab.Name = "PlaygroundsTab";
            PlaygroundsTab.Size = new Size(94, 29);
            PlaygroundsTab.TabIndex = 6;
            PlaygroundsTab.Text = "Playgrounds";
            PlaygroundsTab.UseVisualStyleBackColor = true;
            PlaygroundsTab.Click += PlaygroundsTab_Click;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addButton.Location = new Point(576, 512);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 7;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // fromLabel
            // 
            fromLabel.AutoSize = true;
            fromLabel.Location = new Point(3, 21);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(46, 20);
            fromLabel.TabIndex = 8;
            fromLabel.Text = "From:";
            // 
            // toLabel
            // 
            toLabel.AutoSize = true;
            toLabel.Location = new Point(160, 21);
            toLabel.Name = "toLabel";
            toLabel.Size = new Size(28, 20);
            toLabel.TabIndex = 9;
            toLabel.Text = "To:";
            // 
            // toTextBox
            // 
            toTextBox.Location = new Point(194, 19);
            toTextBox.Name = "toTextBox";
            toTextBox.ReadOnly = true;
            toTextBox.Size = new Size(99, 27);
            toTextBox.TabIndex = 10;
            toTextBox.TextAlign = HorizontalAlignment.Center;
            toTextBox.Click += toTextBox_Click;
            // 
            // fromMonthCalendar
            // 
            fromMonthCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fromMonthCalendar.Location = new Point(502, 133);
            fromMonthCalendar.Name = "fromMonthCalendar";
            fromMonthCalendar.TabIndex = 12;
            fromMonthCalendar.Visible = false;
            fromMonthCalendar.DateSelected += fromMonthCalendar_DateSelected;
            fromMonthCalendar.MouseLeave += fromMonthCalendar_MouseLeave;
            // 
            // toMonthCalendar
            // 
            toMonthCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            toMonthCalendar.Location = new Point(502, 133);
            toMonthCalendar.Name = "toMonthCalendar";
            toMonthCalendar.TabIndex = 13;
            toMonthCalendar.Visible = false;
            toMonthCalendar.DateSelected += toMonthCalendar_DateSelectedAsync;
            toMonthCalendar.MouseLeave += toMonthCalendar_MouseLeave;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(fromLabel);
            panel1.Controls.Add(fromTextBox);
            panel1.Controls.Add(toLabel);
            panel1.Controls.Add(toTextBox);
            panel1.Location = new Point(477, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 49);
            panel1.TabIndex = 14;
            // 
            // fromTextBox
            // 
            fromTextBox.Location = new Point(55, 19);
            fromTextBox.Name = "fromTextBox";
            fromTextBox.ReadOnly = true;
            fromTextBox.Size = new Size(99, 27);
            fromTextBox.TabIndex = 11;
            fromTextBox.TextAlign = HorizontalAlignment.Center;
            fromTextBox.Click += fromTextBox_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(panel1);
            Controls.Add(toMonthCalendar);
            Controls.Add(fromMonthCalendar);
            Controls.Add(addButton);
            Controls.Add(comboBox1);
            Controls.Add(PlaygroundsTab);
            Controls.Add(DevicesTab);
            Controls.Add(infoButton);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button1);
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            Text = "Company Database";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)slideBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)slideBindingSource1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button infoButton;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private BindingSource slideBindingSource;
        private BindingSource slideBindingSource1;
        private Button DevicesTab;
        private Button PlaygroundsTab;
        private Button addButton;
        private Label fromLabel;
        private Label toLabel;
        private TextBox toTextBox;
        private MonthCalendar fromMonthCalendar;
        private MonthCalendar toMonthCalendar;
        private Panel panel1;
        private TextBox fromTextBox;
    }
}