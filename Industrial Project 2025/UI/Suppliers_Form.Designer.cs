namespace Industrial_Project_2025
{
    partial class Suppliers_Form
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
            SuppliersL = new Label();
            SuppliersListLV = new ListView();
            BackBTN = new Button();
            AddSupplierBTN = new Button();
            HelpButton = new Button();
            CMSlistView = new ContextMenuStrip(components);
            TSMIdelete = new ToolStripMenuItem();
            TSMIviewEdit = new ToolStripMenuItem();
            CMSlistView.SuspendLayout();
            SuspendLayout();
            // 
            // SuppliersL
            // 
            SuppliersL.AutoSize = true;
            SuppliersL.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SuppliersL.Location = new Point(345, -2);
            SuppliersL.Name = "SuppliersL";
            SuppliersL.Size = new Size(126, 37);
            SuppliersL.TabIndex = 0;
            SuppliersL.Text = "Suppliers";
            // 
            // SuppliersListLV
            // 
            SuppliersListLV.Location = new Point(12, 41);
            SuppliersListLV.Name = "SuppliersListLV";
            SuppliersListLV.Size = new Size(776, 370);
            SuppliersListLV.TabIndex = 1;
            SuppliersListLV.UseCompatibleStateImageBehavior = false;
            SuppliersListLV.ColumnClick += SuppliersListLV_ColumnClick;
            SuppliersListLV.MouseClick += SuppliersListLV_MouseClick;
            // 
            // BackBTN
            // 
            BackBTN.Location = new Point(12, 12);
            BackBTN.Name = "BackBTN";
            BackBTN.Size = new Size(88, 23);
            BackBTN.TabIndex = 4;
            BackBTN.Text = "Back";
            BackBTN.UseVisualStyleBackColor = true;
            BackBTN.Click += BackBTN_Click;
            // 
            // AddSupplierBTN
            // 
            AddSupplierBTN.Location = new Point(700, 12);
            AddSupplierBTN.Name = "AddSupplierBTN";
            AddSupplierBTN.Size = new Size(88, 23);
            AddSupplierBTN.TabIndex = 5;
            AddSupplierBTN.Text = "Add Supplier";
            AddSupplierBTN.UseVisualStyleBackColor = true;
            AddSupplierBTN.Click += AddSupplierBTN_Click;
            // 
            // HelpButton
            // 
            HelpButton.Location = new Point(646, 12);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(48, 23);
            HelpButton.TabIndex = 6;
            HelpButton.Text = "Help";
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.Click += HelpButton_Click;
            // 
            // CMSlistView
            // 
            CMSlistView.Items.AddRange(new ToolStripItem[] { TSMIdelete, TSMIviewEdit });
            CMSlistView.Name = "CMSlistView";
            CMSlistView.Size = new Size(125, 48);
            // 
            // TSMIdelete
            // 
            TSMIdelete.Name = "TSMIdelete";
            TSMIdelete.Size = new Size(124, 22);
            TSMIdelete.Text = "Delete";
            TSMIdelete.Click += TSMIdelete_Click;
            // 
            // TSMIviewEdit
            // 
            TSMIviewEdit.Name = "TSMIviewEdit";
            TSMIviewEdit.Size = new Size(124, 22);
            TSMIviewEdit.Text = "View/Edit";
            TSMIviewEdit.Click += TSMIviewEdit_Click;
            // 
            // Suppliers_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 422);
            Controls.Add(HelpButton);
            Controls.Add(AddSupplierBTN);
            Controls.Add(BackBTN);
            Controls.Add(SuppliersListLV);
            Controls.Add(SuppliersL);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Suppliers_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suppliers";
            FormClosing += Suppliers_Form_FormClosing;
            Load += Suppliers_Form_Load;
            CMSlistView.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SuppliersL;
        private ListView SuppliersListLV;
        private Button BackBTN;
        private Button AddSupplierBTN;
        private Button HelpButton;
        private ContextMenuStrip CMSlistView;
        private ToolStripMenuItem TSMIdelete;
        private ToolStripMenuItem TSMIviewEdit;
    }
}