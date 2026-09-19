namespace Industrial_Project_2025
{
    partial class Home_Form
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
            home_title = new TextBox();
            home_calendar = new MonthCalendar();
            contract_screen_open_button = new Button();
            supplier_screen_open_button = new Button();
            price_view_button = new Button();
            endingContractsLV = new ListView();
            label1 = new Label();
            SuspendLayout();
            // 
            // home_title
            // 
            home_title.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            home_title.BackColor = SystemColors.Control;
            home_title.BorderStyle = BorderStyle.None;
            home_title.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            home_title.Location = new Point(265, 12);
            home_title.Name = "home_title";
            home_title.Size = new Size(240, 26);
            home_title.TabIndex = 0;
            home_title.TabStop = false;
            home_title.Text = "Steinbach Hatchery Logistics";
            // 
            // home_calendar
            // 
            home_calendar.BackColor = SystemColors.Control;
            home_calendar.Location = new Point(18, 53);
            home_calendar.Name = "home_calendar";
            home_calendar.ShowTodayCircle = false;
            home_calendar.TabIndex = 1;
            // 
            // contract_screen_open_button
            // 
            contract_screen_open_button.Location = new Point(18, 241);
            contract_screen_open_button.Name = "contract_screen_open_button";
            contract_screen_open_button.Size = new Size(227, 23);
            contract_screen_open_button.TabIndex = 3;
            contract_screen_open_button.Text = "Contracts";
            contract_screen_open_button.UseVisualStyleBackColor = true;
            contract_screen_open_button.Click += contract_screen_open_button_Click;
            // 
            // supplier_screen_open_button
            // 
            supplier_screen_open_button.Location = new Point(18, 270);
            supplier_screen_open_button.Name = "supplier_screen_open_button";
            supplier_screen_open_button.Size = new Size(227, 23);
            supplier_screen_open_button.TabIndex = 4;
            supplier_screen_open_button.Text = "Suppliers";
            supplier_screen_open_button.UseVisualStyleBackColor = true;
            supplier_screen_open_button.Click += supplier_screen_open_button_Click;
            // 
            // price_view_button
            // 
            price_view_button.Location = new Point(18, 299);
            price_view_button.Name = "price_view_button";
            price_view_button.Size = new Size(227, 23);
            price_view_button.TabIndex = 5;
            price_view_button.Text = "Price View\r\n\r\n";
            price_view_button.UseVisualStyleBackColor = true;
            price_view_button.Click += button1_Click;
            // 
            // endingContractsLV
            // 
            endingContractsLV.Location = new Point(277, 95);
            endingContractsLV.Name = "endingContractsLV";
            endingContractsLV.Size = new Size(456, 120);
            endingContractsLV.TabIndex = 6;
            endingContractsLV.UseCompatibleStateImageBehavior = false;
            endingContractsLV.ColumnClick += endingContractsLV_ColumnClick_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(407, 63);
            label1.Name = "label1";
            label1.Size = new Size(196, 20);
            label1.TabIndex = 7;
            label1.Text = "This week's ending contracts";
            // 
            // Home_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 352);
            Controls.Add(label1);
            Controls.Add(endingContractsLV);
            Controls.Add(price_view_button);
            Controls.Add(supplier_screen_open_button);
            Controls.Add(contract_screen_open_button);
            Controls.Add(home_calendar);
            Controls.Add(home_title);
            Name = "Home_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Steinbach Hatchery Logistics Software";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox home_title;
        private MonthCalendar home_calendar;
        private Button contract_screen_open_button;
        private Button supplier_screen_open_button;
        private Button price_view_button;
        private ListView endingContractsLV;
        private Label label1;
    }
}
