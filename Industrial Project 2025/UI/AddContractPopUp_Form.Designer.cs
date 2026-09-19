namespace Industrial_Project_2025
{
    partial class AddContractPopUp_Form
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
            backButton = new Button();
            ContractSourceTB = new TextBox();
            saveButton = new Button();
            ContractCommodityCB = new ComboBox();
            AmountBoughtNUP = new NumericUpDown();
            ContractAmountL = new Label();
            AmountReceivedNUP = new NumericUpDown();
            AmountReceivedL = new Label();
            CommodityChoiceL = new Label();
            TotalCostL = new Label();
            totalCostNUD = new NumericUpDown();
            CALcontractStartDate = new MonthCalendar();
            nextButton = new Button();
            CALcontractEndDate = new MonthCalendar();
            contractStartDateL = new Label();
            contractEndDateL = new Label();
            ((System.ComponentModel.ISupportInitialize)AmountBoughtNUP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AmountReceivedNUP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)totalCostNUD).BeginInit();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 0;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // ContractSourceTB
            // 
            ContractSourceTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ContractSourceTB.Location = new Point(12, 67);
            ContractSourceTB.Name = "ContractSourceTB";
            ContractSourceTB.PlaceholderText = "Supplier Name (type to start autocomplete)";
            ContractSourceTB.Size = new Size(321, 23);
            ContractSourceTB.TabIndex = 1;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(258, 247);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Visible = false;
            saveButton.Click += saveButton_Click;
            // 
            // ContractCommodityCB
            // 
            ContractCommodityCB.DropDownStyle = ComboBoxStyle.DropDownList;
            ContractCommodityCB.FormattingEnabled = true;
            ContractCommodityCB.Items.AddRange(new object[] { " Corn", " Wheat", " Soybean_Meal", " Canola_Meal" });
            ContractCommodityCB.Location = new Point(144, 96);
            ContractCommodityCB.Name = "ContractCommodityCB";
            ContractCommodityCB.Size = new Size(189, 23);
            ContractCommodityCB.TabIndex = 6;
            // 
            // AmountBoughtNUP
            // 
            AmountBoughtNUP.DecimalPlaces = 2;
            AmountBoughtNUP.Location = new Point(144, 127);
            AmountBoughtNUP.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            AmountBoughtNUP.Name = "AmountBoughtNUP";
            AmountBoughtNUP.Size = new Size(189, 23);
            AmountBoughtNUP.TabIndex = 7;
            // 
            // ContractAmountL
            // 
            ContractAmountL.AutoSize = true;
            ContractAmountL.Location = new Point(12, 130);
            ContractAmountL.Name = "ContractAmountL";
            ContractAmountL.Size = new Size(121, 15);
            ContractAmountL.TabIndex = 8;
            ContractAmountL.Text = "Amount Bought (Kg):";
            // 
            // AmountReceivedNUP
            // 
            AmountReceivedNUP.DecimalPlaces = 2;
            AmountReceivedNUP.Location = new Point(144, 157);
            AmountReceivedNUP.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            AmountReceivedNUP.Name = "AmountReceivedNUP";
            AmountReceivedNUP.Size = new Size(189, 23);
            AmountReceivedNUP.TabIndex = 9;
            // 
            // AmountReceivedL
            // 
            AmountReceivedL.AutoSize = true;
            AmountReceivedL.Location = new Point(13, 159);
            AmountReceivedL.Name = "AmountReceivedL";
            AmountReceivedL.Size = new Size(125, 15);
            AmountReceivedL.TabIndex = 10;
            AmountReceivedL.Text = "Already Received (Kg):";
            // 
            // CommodityChoiceL
            // 
            CommodityChoiceL.AutoSize = true;
            CommodityChoiceL.Location = new Point(13, 99);
            CommodityChoiceL.Name = "CommodityChoiceL";
            CommodityChoiceL.Size = new Size(117, 15);
            CommodityChoiceL.TabIndex = 11;
            CommodityChoiceL.Text = "Choose Commodity:";
            // 
            // TotalCostL
            // 
            TotalCostL.AutoSize = true;
            TotalCostL.Location = new Point(13, 188);
            TotalCostL.Name = "TotalCostL";
            TotalCostL.Size = new Size(97, 15);
            TotalCostL.TabIndex = 13;
            TotalCostL.Text = "Cost / MT (CAD):";
            // 
            // totalCostNUD
            // 
            totalCostNUD.DecimalPlaces = 2;
            totalCostNUD.Location = new Point(144, 186);
            totalCostNUD.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            totalCostNUD.Name = "totalCostNUD";
            totalCostNUD.Size = new Size(189, 23);
            totalCostNUD.TabIndex = 12;
            // 
            // CALcontractStartDate
            // 
            CALcontractStartDate.Location = new Point(61, 73);
            CALcontractStartDate.Name = "CALcontractStartDate";
            CALcontractStartDate.ShowTodayCircle = false;
            CALcontractStartDate.TabIndex = 14;
            CALcontractStartDate.Visible = false;
            CALcontractStartDate.DateSelected += CALcontractStartDate_DateSelected;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(258, 12);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(75, 23);
            nextButton.TabIndex = 16;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // CALcontractEndDate
            // 
            CALcontractEndDate.Location = new Point(61, 73);
            CALcontractEndDate.Name = "CALcontractEndDate";
            CALcontractEndDate.ShowTodayCircle = false;
            CALcontractEndDate.TabIndex = 18;
            CALcontractEndDate.Visible = false;
            CALcontractEndDate.DateSelected += CALcontractEndDate_DateSelected;
            // 
            // contractStartDateL
            // 
            contractStartDateL.AutoSize = true;
            contractStartDateL.Location = new Point(104, 49);
            contractStartDateL.Name = "contractStartDateL";
            contractStartDateL.Size = new Size(137, 15);
            contractStartDateL.TabIndex = 19;
            contractStartDateL.Text = "Select contract start date";
            contractStartDateL.Visible = false;
            // 
            // contractEndDateL
            // 
            contractEndDateL.AutoSize = true;
            contractEndDateL.Location = new Point(104, 49);
            contractEndDateL.Name = "contractEndDateL";
            contractEndDateL.Size = new Size(134, 15);
            contractEndDateL.TabIndex = 20;
            contractEndDateL.Text = "Select contract end date";
            contractEndDateL.Visible = false;
            // 
            // AddContractPopUp_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 282);
            ControlBox = false;
            Controls.Add(contractEndDateL);
            Controls.Add(contractStartDateL);
            Controls.Add(nextButton);
            Controls.Add(TotalCostL);
            Controls.Add(totalCostNUD);
            Controls.Add(CommodityChoiceL);
            Controls.Add(AmountReceivedL);
            Controls.Add(AmountReceivedNUP);
            Controls.Add(ContractAmountL);
            Controls.Add(AmountBoughtNUP);
            Controls.Add(ContractCommodityCB);
            Controls.Add(saveButton);
            Controls.Add(ContractSourceTB);
            Controls.Add(backButton);
            Controls.Add(CALcontractStartDate);
            Controls.Add(CALcontractEndDate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddContractPopUp_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Contract";
            ((System.ComponentModel.ISupportInitialize)AmountBoughtNUP).EndInit();
            ((System.ComponentModel.ISupportInitialize)AmountReceivedNUP).EndInit();
            ((System.ComponentModel.ISupportInitialize)totalCostNUD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private TextBox ContractSourceTB;
        private Button saveButton;
        private ComboBox ContractCommodityCB;
        private NumericUpDown AmountBoughtNUP;
        private Label ContractAmountL;
        private NumericUpDown AmountReceivedNUP;
        private Label AmountReceivedL;
        private Label CommodityChoiceL;
        private Label TotalCostL;
        private NumericUpDown totalCostNUD;
        private MonthCalendar CALcontractStartDate;
        private Button nextButton;
        private MonthCalendar CALcontractEndDate;
        private Label contractStartDateL;
        private Label contractEndDateL;
    }
}