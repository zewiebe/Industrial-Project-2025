namespace Industrial_Project_2025
{
    partial class AddSupplierPopUp_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplierPopUp_Form));
            backBTN = new Button();
            SaveBTN = new Button();
            nameL = new Label();
            nameTB = new TextBox();
            phoneNumberTB = new TextBox();
            phoneNumberL = new Label();
            emailTB = new TextBox();
            emailL = new Label();
            addressTB = new TextBox();
            addressL = new Label();
            titleL = new Label();
            SuspendLayout();
            // 
            // backBTN
            // 
            backBTN.Location = new Point(12, 12);
            backBTN.Name = "backBTN";
            backBTN.Size = new Size(75, 23);
            backBTN.TabIndex = 0;
            backBTN.Text = "Back";
            backBTN.UseVisualStyleBackColor = true;
            backBTN.Click += backBTN_Click;
            // 
            // SaveBTN
            // 
            SaveBTN.Location = new Point(304, 12);
            SaveBTN.Name = "SaveBTN";
            SaveBTN.Size = new Size(75, 23);
            SaveBTN.TabIndex = 1;
            SaveBTN.Text = "Save";
            SaveBTN.UseVisualStyleBackColor = true;
            SaveBTN.Click += SaveBTN_Click;
            // 
            // nameL
            // 
            nameL.AutoSize = true;
            nameL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameL.Location = new Point(12, 88);
            nameL.Name = "nameL";
            nameL.Size = new Size(98, 17);
            nameL.TabIndex = 2;
            nameL.Text = "Supplier Name:";
            // 
            // nameTB
            // 
            nameTB.Location = new Point(116, 87);
            nameTB.Name = "nameTB";
            nameTB.Size = new Size(263, 23);
            nameTB.TabIndex = 3;
            // 
            // phoneNumberTB
            // 
            phoneNumberTB.Location = new Point(116, 174);
            phoneNumberTB.Name = "phoneNumberTB";
            phoneNumberTB.Size = new Size(263, 23);
            phoneNumberTB.TabIndex = 5;
            // 
            // phoneNumberL
            // 
            phoneNumberL.AutoSize = true;
            phoneNumberL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneNumberL.Location = new Point(12, 175);
            phoneNumberL.Name = "phoneNumberL";
            phoneNumberL.Size = new Size(99, 17);
            phoneNumberL.TabIndex = 4;
            phoneNumberL.Text = "Phone Number:";
            // 
            // emailTB
            // 
            emailTB.Location = new Point(60, 145);
            emailTB.Name = "emailTB";
            emailTB.Size = new Size(319, 23);
            emailTB.TabIndex = 7;
            // 
            // emailL
            // 
            emailL.AutoSize = true;
            emailL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailL.Location = new Point(12, 146);
            emailL.Name = "emailL";
            emailL.Size = new Size(42, 17);
            emailL.TabIndex = 6;
            emailL.Text = "Email:";
            // 
            // addressTB
            // 
            addressTB.Location = new Point(77, 116);
            addressTB.Name = "addressTB";
            addressTB.Size = new Size(302, 23);
            addressTB.TabIndex = 9;
            // 
            // addressL
            // 
            addressL.AutoSize = true;
            addressL.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressL.Location = new Point(12, 117);
            addressL.Name = "addressL";
            addressL.Size = new Size(59, 17);
            addressL.TabIndex = 8;
            addressL.Text = "Address:";
            // 
            // titleL
            // 
            titleL.AutoSize = true;
            titleL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleL.Location = new Point(143, 41);
            titleL.Name = "titleL";
            titleL.Size = new Size(121, 21);
            titleL.TabIndex = 10;
            titleL.Text = "Supplier Builder";
            // 
            // AddSupplierPopUp_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 240);
            ControlBox = false;
            Controls.Add(titleL);
            Controls.Add(addressTB);
            Controls.Add(addressL);
            Controls.Add(emailTB);
            Controls.Add(emailL);
            Controls.Add(phoneNumberTB);
            Controls.Add(phoneNumberL);
            Controls.Add(nameTB);
            Controls.Add(nameL);
            Controls.Add(SaveBTN);
            Controls.Add(backBTN);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddSupplierPopUp_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Supplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backBTN;
        private Button SaveBTN;
        private Label nameL;
        private TextBox nameTB;
        private TextBox phoneNumberTB;
        private Label phoneNumberL;
        private TextBox emailTB;
        private Label emailL;
        private TextBox addressTB;
        private Label addressL;
        private Label titleL;
    }
}