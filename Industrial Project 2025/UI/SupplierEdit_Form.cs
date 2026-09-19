using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; 


namespace Industrial_Project_2025
{
    internal partial class SupplierEdit_Form : Form
    {
        // Attributes
        private Business supplier;
        private ContractsStub contractsStub;
        private BusinessesStub businessesStub;
        private Suppliers_Form suppliers_Form;
        private ContractColumnSorter lvwColumnSorter;

        // Constructor
        /*        public SupplierEdit_Form(ContractsStub contractsStub, Business business, BusinessesStub businessesStub, Suppliers_Form suppliers_Form)
                {
                    InitializeComponent();
                    this.AutoScaleMode = AutoScaleMode.Dpi;

                    this.supplier = business;
                    this.contractsStub = contractsStub;
                    this.businessesStub = businessesStub;
                    this.suppliers_Form = suppliers_Form;

                    lvwColumnSorter = new ContractColumnSorter(); // Create an instance of a ListView column sorter and assign it to the ListView control.
                    this.contractLV.ListViewItemSorter = lvwColumnSorter; // Set the ListView column sorter to the ListView control.
                }*/

        public SupplierEdit_Form(Business business, Suppliers_Form suppliers_Form)
        {
            InitializeComponent();
            this.supplier = business;
            this.suppliers_Form = suppliers_Form;
            lvwColumnSorter = new ContractColumnSorter(); // Create an instance of a ListView column sorter and assign it to the ListView control.
            this.contractLV.ListViewItemSorter = lvwColumnSorter; // Set the ListView column sorter to the ListView control.
        }

        // Event Handlers
        private void SupplierEdit_Form_Load_1(object sender, EventArgs e)
        {
            // Set the text boxes to the supplier's details
            supplierNameTB.Text = supplier.GetName();
            addressTB.Text = supplier.GetAddress();
            emailTB.Text = supplier.GetEmail();
            phoneNumberTB.Text = supplier.GetPhoneNumber();

            // Set up the ListView
            contractLV.View = View.Details;
            contractLV.FullRowSelect = true;
            // Add columns
            contractLV.Columns.Add("Commodity");
            contractLV.Columns.Add("Amount Requested (kg)");
            contractLV.Columns.Add("End Date");
            contractLV.Columns.Add("Cost (CAD)");
            contractLV.Columns.Add("Status");

            // Fill the list view
            FillContractListView(contractLV);

            // Set the column to sort by End Date column (which is the third column, index 2)
            lvwColumnSorter.SortColumn = 2;
            lvwColumnSorter.Order = SortOrder.Ascending;
            // Perform the sort
            contractLV.Sort();

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.contractLV.Columns)
            {
                ch.Width = -2;
            }
            setuponTimeL();
        }

        private void setuponTimeL()
        {
            if (supplier.GetRatings().Count == 0)
            {
                onTimeL.Text = "This business has no completed records on file yet,\ncheck back again after one is completed to\nsee their on-time percentage";
                int x = (this.Width - onTimeL.Width) / 2;
                onTimeL.Location = new Point(x, onTimeL.Location.Y);
            }
            else
            { 
                onTimeL.Text = "This supplier is on-time " + supplier.GetAverageRating().ToString() + "% of the time";
                int x = (this.Width - onTimeL.Width) / 2;
                onTimeL.Location = new Point(x, onTimeL.Location.Y);
            }
        }

        private void contractLV_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.contractLV.Sort();
        }

        private void editToggleCB_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the form between editing and viewing mode
            if (editToggleCB.Checked)
            {
                editToggleCB.Text = "Editing";
            }
            else
            {
                editToggleCB.Text = "Viewing";
            }

            // Enable or disable the text boxes
            supplierNameTB.Enabled = editToggleCB.Checked;
            addressTB.Enabled = editToggleCB.Checked;
            emailTB.Enabled = editToggleCB.Checked;
            phoneNumberTB.Enabled = editToggleCB.Checked;
        }

        private void doneBTN_Click(object sender, EventArgs e)
        {
            // Check if the inputs are valid
            if (!checkInputs())
            {
                return;
            }

            // Create a new supplier object with the updated values
            Business newSupplier = new Business();
            newSupplier.SetId(supplier.GetId());
            newSupplier.SetName(supplierNameTB.Text);
            newSupplier.SetAddress(addressTB.Text);
            newSupplier.SetEmail(emailTB.Text);
            newSupplier.SetPhoneNumber(phoneNumberTB.Text);

            if (compareInputs()) // If changes were made
            {

                // Prompt the user to confirm the changes
                var confirmResult = MessageBox.Show("Are you sure you want to save the changes?", "Confirm Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    //businessesStub.updateBusiness(newSupplier); // Update the supplier in the businesses list
                    DataAccess.UpdateBusiness(newSupplier); // Update the supplier in the database
                    suppliers_Form.EditBusiness(newSupplier);   // Update the supplier in the list view

                    this.Hide();
                }
                else
                {
                    // If the user clicks "No", close the form
                    this.Hide();
                }
            }
            // If no changes were made, close the form
            else
            {
                this.Hide();
            }
        }


        // Helper Methods
        // Fill the list view with contracts
        private void FillContractListView(ListView listView)
        {
            //List<Contract> contractsList = contractsStub.getContracts();
            List<Contract> contractsList = DataAccess.GetAllContracts();

            // Loop through the contracts and add them to the list view
            foreach (Contract contract in contractsList)
            {
                // Check if the contract is associated with the supplier
                if (contract.GetSupplier().GetId() == supplier.GetId())
                {
                    ListViewItem contractItem = LVItemCreator(contract);
                    listView.Items.Add(contractItem);
                }
            }
        }

        // Create a list view item
        private ListViewItem LVItemCreator(Contract contract)
        {

            ListViewItem contractItem = new ListViewItem(enumToString(contract.GetCommodity()));
            contractItem.SubItems.Add(contract.GetQuantity().ToString());
            contractItem.SubItems.Add(contract.GetEndDate().ToShortDateString());
            contractItem.SubItems.Add(contract.GetPrice().ToString());
            contractItem.SubItems.Add(contract.IsOpen() ? "Open" : "Closed");

            return contractItem;
        }

        // Check if the inputs are different from the supplier's details
        private bool compareInputs()
        {
            bool changed = false;
            // Compare the inputs to the supplier's details
            if (supplierNameTB.Text != supplier.GetName() || addressTB.Text != supplier.GetAddress() || emailTB.Text != supplier.GetEmail() || phoneNumberTB.Text != supplier.GetPhoneNumber())
            {
                changed = true;
            }
            return changed;
        }

        // Check if the inputs are valid
        private bool checkInputs()
        {
            // Check if the text boxes are empty
            if (supplierNameTB.Text == "")
            {
                MessageBox.Show("Please fill the fields. At minimum supplier name must be inputted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Define a regex pattern for phone number validation
            string phoneNumberPattern = @"^\+?[1-9]\d{1,14}$"; // E.164 format

            // Validate the phone number
            if (!Regex.IsMatch(phoneNumberTB.Text, phoneNumberPattern) || phoneNumberTB.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Convert enum to string
        private string enumToString(Constants.Commodity commodity)
        {
            switch (commodity)
            {
                case Constants.Commodity.Corn:
                    return "Corn";
                case Constants.Commodity.Wheat:
                    return "Wheat";
                case Constants.Commodity.Soybean_Meal:
                    return "Soybean Meal";
                case Constants.Commodity.Canola_Meal:
                    return "Canola Meal";
                default:
                    return "Unknown";
            }
        }
    }
}
