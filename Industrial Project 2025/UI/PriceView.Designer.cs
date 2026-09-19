using Industrial_Project_2025.wpfControls;


namespace Industrial_Project_2025
{
    partial class PriceView
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
            comboBox1 = new ComboBox();
            viewSelectBox = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.AllowDrop = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(5, 5);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(129, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // viewSelectBox
            // 
            viewSelectBox.AllowDrop = true;
            viewSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;
            viewSelectBox.FormattingEnabled = true;
            viewSelectBox.Items.AddRange(new object[] { "Price_View", "Month_Allocation" });
            viewSelectBox.Location = new Point(5, 29);
            viewSelectBox.Margin = new Padding(2);
            viewSelectBox.Name = "viewSelectBox";
            viewSelectBox.Size = new Size(129, 23);
            viewSelectBox.TabIndex = 1;
            viewSelectBox.SelectedIndexChanged += viewSelectBox_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(43, 52);
            numericUpDown1.Margin = new Padding(2);
            numericUpDown1.Maximum = new decimal(new int[] { 202400, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1500, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(89, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 52);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 4;
            label1.Text = "Year";
            // 
            // PriceView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1784, 961);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(viewSelectBox);
            Controls.Add(comboBox1);
            Margin = new Padding(2);
            Name = "PriceView";
            Text = "Price_View";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private ComboBox viewSelectBox;
        private NumericUpDown numericUpDown1;
        private Label label1;
    }
}