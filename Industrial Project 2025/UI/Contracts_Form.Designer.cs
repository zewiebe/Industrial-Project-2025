namespace Industrial_Project_2025
{
    partial class Contracts_Form
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
            contract_List_View = new ListView();
            Add_Contract_Button = new Button();
            contracts_Form_Back_Button = new Button();
            HelpButton = new Button();
            ContractCheckBox = new CheckBox();
            removeMU = new ToolStripMenuItem();
            viewEditMI = new ToolStripMenuItem();
            CMSlistView = new ContextMenuStrip(components);
            TSMIdelete = new ToolStripMenuItem();
            TSMIviewEdit = new ToolStripMenuItem();
            label1 = new Label();
            TSMIclose = new ToolStripMenuItem();
            CMSlistView.SuspendLayout();
            SuspendLayout();
            // 
            // contract_List_View
            // 
            contract_List_View.Location = new Point(34, 41);
            contract_List_View.Name = "contract_List_View";
            contract_List_View.Size = new Size(926, 498);
            contract_List_View.TabIndex = 0;
            contract_List_View.UseCompatibleStateImageBehavior = false;
            contract_List_View.ColumnClick += contract_List_View_ColumnClick;
            contract_List_View.MouseClick += contract_List_View_MouseClick;
            contract_List_View.MouseDoubleClick += contract_List_View_MouseDoubleClick;
            // 
            // Add_Contract_Button
            // 
            Add_Contract_Button.Location = new Point(872, 12);
            Add_Contract_Button.Name = "Add_Contract_Button";
            Add_Contract_Button.Size = new Size(88, 23);
            Add_Contract_Button.TabIndex = 2;
            Add_Contract_Button.Text = "Add Contract";
            Add_Contract_Button.UseVisualStyleBackColor = true;
            Add_Contract_Button.Click += Add_Contract_Button_Click;
            // 
            // contracts_Form_Back_Button
            // 
            contracts_Form_Back_Button.Location = new Point(34, 12);
            contracts_Form_Back_Button.Name = "contracts_Form_Back_Button";
            contracts_Form_Back_Button.Size = new Size(88, 23);
            contracts_Form_Back_Button.TabIndex = 3;
            contracts_Form_Back_Button.Text = "Back";
            contracts_Form_Back_Button.UseVisualStyleBackColor = true;
            contracts_Form_Back_Button.Click += contracts_Form_Back_Button_Click;
            // 
            // HelpButton
            // 
            HelpButton.Location = new Point(912, 550);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(48, 23);
            HelpButton.TabIndex = 4;
            HelpButton.Text = "Help";
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.Click += HelpButton_Click;
            // 
            // ContractCheckBox
            // 
            ContractCheckBox.AutoSize = true;
            ContractCheckBox.Location = new Point(775, 554);
            ContractCheckBox.Name = "ContractCheckBox";
            ContractCheckBox.Size = new Size(131, 19);
            ContractCheckBox.TabIndex = 5;
            ContractCheckBox.Text = "Colour Coordinated";
            ContractCheckBox.UseVisualStyleBackColor = true;
            ContractCheckBox.Click += ContractCheckBox_Click;
            // 
            // removeMU
            // 
            removeMU.Name = "removeMU";
            removeMU.Size = new Size(124, 22);
            removeMU.Text = "Remove";
            // 
            // viewEditMI
            // 
            viewEditMI.Name = "viewEditMI";
            viewEditMI.Size = new Size(124, 22);
            viewEditMI.Text = "View/Edit";
            // 
            // CMSlistView
            // 
            CMSlistView.Items.AddRange(new ToolStripItem[] { TSMIdelete, TSMIviewEdit, TSMIclose });
            CMSlistView.Name = "CMSlistView";
            CMSlistView.Size = new Size(181, 92);
            // 
            // TSMIdelete
            // 
            TSMIdelete.Name = "TSMIdelete";
            TSMIdelete.Size = new Size(180, 22);
            TSMIdelete.Text = "Delete";
            TSMIdelete.Click += TSMIdelete_Click;
            // 
            // TSMIviewEdit
            // 
            TSMIviewEdit.Name = "TSMIviewEdit";
            TSMIviewEdit.Size = new Size(180, 22);
            TSMIviewEdit.Text = "View/Edit";
            TSMIviewEdit.Click += TSMIedit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(439, 1);
            label1.Name = "label1";
            label1.Size = new Size(129, 37);
            label1.TabIndex = 6;
            label1.Text = "Contracts";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TSMIclose
            // 
            TSMIclose.Name = "TSMIclose";
            TSMIclose.Size = new Size(180, 22);
            TSMIclose.Text = "Close contract";
            TSMIclose.Click += TSMIclose_Click;
            // 
            // Contracts_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 585);
            Controls.Add(label1);
            Controls.Add(ContractCheckBox);
            Controls.Add(HelpButton);
            Controls.Add(contracts_Form_Back_Button);
            Controls.Add(Add_Contract_Button);
            Controls.Add(contract_List_View);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Contracts_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Steinbach Hatchery Logistics Software";
            FormClosing += Contracts_Form_FormClosing;
            Load += Contracts_Form_Load;
            CMSlistView.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView contract_List_View;
        private Button Add_Contract_Button;
        private Button contracts_Form_Back_Button;
        private Button HelpButton;
        private CheckBox ContractCheckBox;
        private ToolStripMenuItem removeMU;
        private ToolStripMenuItem viewEditMI;
        private ContextMenuStrip CMSlistView;
        private ToolStripMenuItem TSMIdelete;
        private ToolStripMenuItem TSMIviewEdit;
        private Label label1;
        private ToolStripMenuItem TSMIclose;
    }
}