namespace Industrial_Project_2025
{
    partial class ContractEdit_Form
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
            titleL = new Label();
            commodityL = new Label();
            requestedL = new Label();
            receivedL = new Label();
            priceL = new Label();
            startDateL = new Label();
            dueDateL = new Label();
            statusL = new Label();
            requestedNUD = new NumericUpDown();
            recievedNUD = new NumericUpDown();
            costNUD = new NumericUpDown();
            startDateTB = new TextBox();
            endDateTB = new TextBox();
            contractCommodityCB = new ComboBox();
            statusCB = new ComboBox();
            doneBTN = new Button();
            ContractSourceTB = new TextBox();
            supplierL = new Label();
            editToggleCB = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)requestedNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recievedNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costNUD).BeginInit();
            SuspendLayout();
            // 
            // titleL
            // 
            titleL.AutoSize = true;
            titleL.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleL.Location = new Point(26, 22);
            titleL.Name = "titleL";
            titleL.Size = new Size(196, 37);
            titleL.TabIndex = 0;
            titleL.Text = "Contract Editor";
            // 
            // commodityL
            // 
            commodityL.AutoSize = true;
            commodityL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            commodityL.Location = new Point(26, 127);
            commodityL.Name = "commodityL";
            commodityL.Size = new Size(82, 17);
            commodityL.TabIndex = 1;
            commodityL.Text = "Commodity: ";
            // 
            // requestedL
            // 
            requestedL.AutoSize = true;
            requestedL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            requestedL.Location = new Point(26, 165);
            requestedL.Name = "requestedL";
            requestedL.Size = new Size(154, 17);
            requestedL.TabIndex = 2;
            requestedL.Text = "Amount Requested (Kg): ";
            // 
            // receivedL
            // 
            receivedL.AutoSize = true;
            receivedL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            receivedL.Location = new Point(26, 202);
            receivedL.Name = "receivedL";
            receivedL.Size = new Size(140, 17);
            receivedL.TabIndex = 3;
            receivedL.Text = "Amount Recieved (Kg):";
            // 
            // priceL
            // 
            priceL.AutoSize = true;
            priceL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            priceL.Location = new Point(26, 240);
            priceL.Name = "priceL";
            priceL.Size = new Size(106, 17);
            priceL.TabIndex = 4;
            priceL.Text = "Cost / MT (CAD):";
            // 
            // startDateL
            // 
            startDateL.AutoSize = true;
            startDateL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startDateL.Location = new Point(26, 279);
            startDateL.Name = "startDateL";
            startDateL.Size = new Size(214, 17);
            startDateL.TabIndex = 7;
            startDateL.Text = "Contract Start Date (MM-DD-YYYY):";
            // 
            // dueDateL
            // 
            dueDateL.AutoSize = true;
            dueDateL.Location = new Point(26, 317);
            dueDateL.Name = "dueDateL";
            dueDateL.Size = new Size(194, 15);
            dueDateL.TabIndex = 8;
            dueDateL.Text = "Contract Due Date (MM-DD-YYYY):";
            // 
            // statusL
            // 
            statusL.AutoSize = true;
            statusL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusL.Location = new Point(26, 351);
            statusL.Name = "statusL";
            statusL.Size = new Size(103, 17);
            statusL.TabIndex = 9;
            statusL.Text = "Contract Status: ";
            // 
            // requestedNUD
            // 
            requestedNUD.DecimalPlaces = 2;
            requestedNUD.Enabled = false;
            requestedNUD.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            requestedNUD.Location = new Point(186, 165);
            requestedNUD.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            requestedNUD.Name = "requestedNUD";
            requestedNUD.Size = new Size(187, 25);
            requestedNUD.TabIndex = 10;
            requestedNUD.ThousandsSeparator = true;
            // 
            // recievedNUD
            // 
            recievedNUD.DecimalPlaces = 2;
            recievedNUD.Enabled = false;
            recievedNUD.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recievedNUD.Location = new Point(186, 202);
            recievedNUD.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            recievedNUD.Name = "recievedNUD";
            recievedNUD.Size = new Size(187, 25);
            recievedNUD.TabIndex = 11;
            recievedNUD.ThousandsSeparator = true;
            // 
            // costNUD
            // 
            costNUD.DecimalPlaces = 2;
            costNUD.Enabled = false;
            costNUD.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            costNUD.Location = new Point(186, 238);
            costNUD.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            costNUD.Name = "costNUD";
            costNUD.Size = new Size(187, 25);
            costNUD.TabIndex = 12;
            costNUD.ThousandsSeparator = true;
            // 
            // startDateTB
            // 
            startDateTB.Enabled = false;
            startDateTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startDateTB.Location = new Point(246, 276);
            startDateTB.Name = "startDateTB";
            startDateTB.Size = new Size(127, 25);
            startDateTB.TabIndex = 15;
            startDateTB.Text = "prevSetDate";
            // 
            // endDateTB
            // 
            endDateTB.Enabled = false;
            endDateTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            endDateTB.Location = new Point(246, 312);
            endDateTB.Name = "endDateTB";
            endDateTB.Size = new Size(127, 25);
            endDateTB.TabIndex = 16;
            endDateTB.Text = "prevSetDate";
            // 
            // contractCommodityCB
            // 
            contractCommodityCB.DropDownStyle = ComboBoxStyle.DropDownList;
            contractCommodityCB.Enabled = false;
            contractCommodityCB.FormattingEnabled = true;
            contractCommodityCB.Items.AddRange(new object[] { " Corn", " Wheat", " Soybean_Meal", " Canola_Meal" });
            contractCommodityCB.Location = new Point(114, 126);
            contractCommodityCB.Name = "contractCommodityCB";
            contractCommodityCB.Size = new Size(259, 23);
            contractCommodityCB.TabIndex = 19;
            // 
            // statusCB
            // 
            statusCB.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCB.Enabled = false;
            statusCB.FormattingEnabled = true;
            statusCB.Items.AddRange(new object[] { "Open", "Closed" });
            statusCB.Location = new Point(135, 351);
            statusCB.Name = "statusCB";
            statusCB.Size = new Size(238, 23);
            statusCB.TabIndex = 20;
            // 
            // doneBTN
            // 
            doneBTN.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            doneBTN.Location = new Point(298, 381);
            doneBTN.Name = "doneBTN";
            doneBTN.Size = new Size(75, 27);
            doneBTN.TabIndex = 21;
            doneBTN.Text = "Done";
            doneBTN.TextAlign = ContentAlignment.TopCenter;
            doneBTN.UseVisualStyleBackColor = true;
            doneBTN.Click += doneBTN_Click;
            // 
            // ContractSourceTB
            // 
            ContractSourceTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ContractSourceTB.Enabled = false;
            ContractSourceTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ContractSourceTB.Location = new Point(95, 88);
            ContractSourceTB.Name = "ContractSourceTB";
            ContractSourceTB.PlaceholderText = "Supplier Name";
            ContractSourceTB.Size = new Size(278, 25);
            ContractSourceTB.TabIndex = 22;
            // 
            // supplierL
            // 
            supplierL.AutoSize = true;
            supplierL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierL.Location = new Point(26, 91);
            supplierL.Name = "supplierL";
            supplierL.Size = new Size(63, 17);
            supplierL.TabIndex = 23;
            supplierL.Text = "Supplier: ";
            // 
            // editToggleCB
            // 
            editToggleCB.Appearance = Appearance.Button;
            editToggleCB.AutoSize = true;
            editToggleCB.CheckAlign = ContentAlignment.MiddleCenter;
            editToggleCB.FlatStyle = FlatStyle.System;
            editToggleCB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editToggleCB.Location = new Point(26, 380);
            editToggleCB.Name = "editToggleCB";
            editToggleCB.Size = new Size(63, 27);
            editToggleCB.TabIndex = 24;
            editToggleCB.Text = "Viewing";
            editToggleCB.TextAlign = ContentAlignment.MiddleCenter;
            editToggleCB.UseVisualStyleBackColor = true;
            editToggleCB.CheckedChanged += editToggleCB_CheckedChanged;
            // 
            // ContractEdit_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 415);
            ControlBox = false;
            Controls.Add(editToggleCB);
            Controls.Add(supplierL);
            Controls.Add(ContractSourceTB);
            Controls.Add(doneBTN);
            Controls.Add(statusCB);
            Controls.Add(contractCommodityCB);
            Controls.Add(endDateTB);
            Controls.Add(startDateTB);
            Controls.Add(costNUD);
            Controls.Add(recievedNUD);
            Controls.Add(requestedNUD);
            Controls.Add(statusL);
            Controls.Add(dueDateL);
            Controls.Add(startDateL);
            Controls.Add(priceL);
            Controls.Add(receivedL);
            Controls.Add(requestedL);
            Controls.Add(commodityL);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ContractEdit_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contract Editor";
            ((System.ComponentModel.ISupportInitialize)requestedNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)recievedNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)costNUD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private Label commodityL;
        private Label requestedL;
        private Label receivedL;
        private Label priceL;
        private Label startDateL;
        private Label dueDateL;
        private Label statusL;
        private NumericUpDown requestedNUD;
        private NumericUpDown recievedNUD;
        private NumericUpDown costNUD;
        private TextBox startDateTB;
        private TextBox endDateTB;
        private ComboBox contractCommodityCB;
        private ComboBox statusCB;
        private Button doneBTN;
        private TextBox ContractSourceTB;
        private Label supplierL;
        private CheckBox editToggleCB;
    }
}