namespace Industrial_Project_2025
{
    partial class SupplierEdit_Form
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            titleL = new Label();
            editToggleCB = new CheckBox();
            supplierL = new Label();
            supplierNameTB = new TextBox();
            doneBTN = new Button();
            addressL = new Label();
            emailL = new Label();
            phoneNumberL = new Label();
            addressTB = new TextBox();
            emailTB = new TextBox();
            phoneNumberTB = new TextBox();
            contractLV = new ListView();
            listViewL = new Label();
            onTimeL = new Label();
            SuspendLayout();
            // 
            // titleL
            // 
            titleL.AutoSize = true;
            titleL.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleL.Location = new Point(26, 22);
            titleL.Name = "titleL";
            titleL.Size = new Size(193, 37);
            titleL.TabIndex = 1;
            titleL.Text = "Supplier Editor";
            // 
            // editToggleCB
            // 
            editToggleCB.Appearance = Appearance.Button;
            editToggleCB.AutoSize = true;
            editToggleCB.CheckAlign = ContentAlignment.MiddleCenter;
            editToggleCB.FlatStyle = FlatStyle.System;
            editToggleCB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editToggleCB.Location = new Point(31, 446);
            editToggleCB.Name = "editToggleCB";
            editToggleCB.Size = new Size(63, 27);
            editToggleCB.TabIndex = 42;
            editToggleCB.Text = "Viewing";
            editToggleCB.TextAlign = ContentAlignment.MiddleCenter;
            editToggleCB.UseVisualStyleBackColor = true;
            editToggleCB.CheckedChanged += editToggleCB_CheckedChanged;
            // 
            // supplierL
            // 
            supplierL.AutoSize = true;
            supplierL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierL.Location = new Point(31, 91);
            supplierL.Name = "supplierL";
            supplierL.Size = new Size(102, 17);
            supplierL.TabIndex = 41;
            supplierL.Text = "Supplier Name: ";
            // 
            // supplierNameTB
            // 
            supplierNameTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            supplierNameTB.Enabled = false;
            supplierNameTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierNameTB.Location = new Point(139, 88);
            supplierNameTB.Name = "supplierNameTB";
            supplierNameTB.PlaceholderText = "Supplier Name";
            supplierNameTB.Size = new Size(239, 25);
            supplierNameTB.TabIndex = 40;
            supplierNameTB.Text = "Minecraft Farms";
            // 
            // doneBTN
            // 
            doneBTN.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            doneBTN.Location = new Point(303, 446);
            doneBTN.Name = "doneBTN";
            doneBTN.Size = new Size(75, 27);
            doneBTN.TabIndex = 39;
            doneBTN.Text = "Done";
            doneBTN.TextAlign = ContentAlignment.TopCenter;
            doneBTN.UseVisualStyleBackColor = true;
            doneBTN.Click += doneBTN_Click;
            // 
            // addressL
            // 
            addressL.AutoSize = true;
            addressL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressL.Location = new Point(31, 131);
            addressL.Name = "addressL";
            addressL.Size = new Size(63, 17);
            addressL.TabIndex = 43;
            addressL.Text = "Address: ";
            // 
            // emailL
            // 
            emailL.AutoSize = true;
            emailL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailL.Location = new Point(31, 172);
            emailL.Name = "emailL";
            emailL.Size = new Size(46, 17);
            emailL.TabIndex = 44;
            emailL.Text = "Email: ";
            // 
            // phoneNumberL
            // 
            phoneNumberL.AutoSize = true;
            phoneNumberL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneNumberL.Location = new Point(31, 210);
            phoneNumberL.Name = "phoneNumberL";
            phoneNumberL.Size = new Size(103, 17);
            phoneNumberL.TabIndex = 45;
            phoneNumberL.Text = "Phone Number: ";
            // 
            // addressTB
            // 
            addressTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            addressTB.Enabled = false;
            addressTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressTB.Location = new Point(100, 128);
            addressTB.Name = "addressTB";
            addressTB.PlaceholderText = "Supplier Name";
            addressTB.Size = new Size(278, 25);
            addressTB.TabIndex = 46;
            addressTB.Text = "99 Plains Biome Way";
            // 
            // emailTB
            // 
            emailTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            emailTB.Enabled = false;
            emailTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailTB.Location = new Point(83, 169);
            emailTB.Name = "emailTB";
            emailTB.PlaceholderText = "Supplier Name";
            emailTB.Size = new Size(295, 25);
            emailTB.TabIndex = 47;
            emailTB.Text = "steve@mcfarms.com";
            // 
            // phoneNumberTB
            // 
            phoneNumberTB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            phoneNumberTB.Enabled = false;
            phoneNumberTB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneNumberTB.Location = new Point(140, 207);
            phoneNumberTB.Name = "phoneNumberTB";
            phoneNumberTB.PlaceholderText = "Supplier Name";
            phoneNumberTB.Size = new Size(238, 25);
            phoneNumberTB.TabIndex = 48;
            phoneNumberTB.Text = "(204) 346-9876";
            // 
            // contractLV
            // 
            contractLV.Location = new Point(31, 335);
            contractLV.Name = "contractLV";
            contractLV.Size = new Size(347, 92);
            contractLV.TabIndex = 49;
            contractLV.UseCompatibleStateImageBehavior = false;
            contractLV.ColumnClick += contractLV_ColumnClick;
            // 
            // listViewL
            // 
            listViewL.AutoSize = true;
            listViewL.Location = new Point(139, 312);
            listViewL.Name = "listViewL";
            listViewL.Size = new Size(132, 15);
            listViewL.TabIndex = 50;
            listViewL.Text = "Contracts with supplier:";
            // 
            // onTimeL
            // 
            onTimeL.AutoSize = true;
            onTimeL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            onTimeL.Location = new Point(88, 245);
            onTimeL.Name = "onTimeL";
            onTimeL.Size = new Size(256, 17);
            onTimeL.TabIndex = 51;
            onTimeL.Text = "Minecraft Farms is on time X% of the time.";
            onTimeL.TextAlign = ContentAlignment.TopCenter;
            // 
            // SupplierEdit_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 485);
            ControlBox = false;
            Controls.Add(onTimeL);
            Controls.Add(listViewL);
            Controls.Add(contractLV);
            Controls.Add(phoneNumberTB);
            Controls.Add(emailTB);
            Controls.Add(addressTB);
            Controls.Add(phoneNumberL);
            Controls.Add(emailL);
            Controls.Add(addressL);
            Controls.Add(editToggleCB);
            Controls.Add(supplierL);
            Controls.Add(supplierNameTB);
            Controls.Add(doneBTN);
            Controls.Add(titleL);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SupplierEdit_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supplier Editor";
            Load += SupplierEdit_Form_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleL;
        private CheckBox editToggleCB;
        private Label supplierL;
        private TextBox supplierNameTB;
        private Button doneBTN;
        private Label addressL;
        private Label emailL;
        private Label phoneNumberL;
        private TextBox addressTB;
        private TextBox emailTB;
        private TextBox phoneNumberTB;
        private ListView contractLV;
        private Label listViewL;
        private Label onTimeL;
    }
}