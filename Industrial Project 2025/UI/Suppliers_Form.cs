using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Industrial_Project_2025
{
    internal partial class Suppliers_Form : Form
    {
        // Attributes
        private Home_Form home_form;
        private SupplierColumnSorter lvwColumnSorter;
        private ContractsStub contractsStub = new ContractsStub();
        private BusinessesStub businessesStub = new BusinessesStub();
        private ListViewItem selectedItem = null;

        // Constructor
        public Suppliers_Form(Home_Form home_form)
        {
            InitializeComponent();

            lvwColumnSorter = new SupplierColumnSorter(); // Create an instance of a ListView column sorter and assign it to the ListView control.
            this.SuppliersListLV.ListViewItemSorter = lvwColumnSorter; // Set the ListView column sorter to the ListView control.

            this.home_form = home_form;
        }

        // Event Handlers
        private void Suppliers_Form_Load(object sender, EventArgs e)
        {
            // Set up the ListView
            SuppliersListLV.View = View.Details;
            SuppliersListLV.FullRowSelect = true;
            // Add columns
            SuppliersListLV.Columns.Add("ID");
            SuppliersListLV.Columns.Add("Name");
            SuppliersListLV.Columns.Add("Address");
            SuppliersListLV.Columns.Add("Email");
            SuppliersListLV.Columns.Add("Phone Number");
            // Fill the list view
            FillSupplierLV(SuppliersListLV);
            // Set the column to sort by Name column (which is the second column, index 1)
            lvwColumnSorter.SortColumn = 1;
            lvwColumnSorter.Order = SortOrder.Ascending;
            // Perform the sort
            SuppliersListLV.Sort();
            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.SuppliersListLV.Columns)
            {
                ch.Width = -2;
            }
        }

        private void TSMIviewEdit_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (selectedItem != null)
            {
                try
                {
                    // Load the business editor page
                    //Business business = businessesStub.getBusinessByName(selectedItem.SubItems[1].Text);
                    Business business = DataAccess.GetBusinessByName(selectedItem.SubItems[1].Text);
                    //SupplierEdit_Form editSupplier = new SupplierEdit_Form(contractsStub, business, businessesStub, this);
                    SupplierEdit_Form editSupplier = new SupplierEdit_Form(business, this);
                    editSupplier.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load the contract editor page. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SuppliersListLV_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Check if an item was clicked
                var focusedItem = SuppliersListLV.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    selectedItem = focusedItem;
                    CMSlistView.Show(Cursor.Position); // Show the context menu
                }
            }
        }

        private void SuppliersListLV_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.SuppliersListLV.Sort();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string introText = "There are a number of functions available from this page, below is a short intro to each:\n\n";
            string editText = "EDITING a supplier: Right click a supplier and selected \"View/Edit\" in the drop down menu. NOTE: You cannot undo this without repeating steps, the old values are not stored.\n\n";
            string deleteText = "DELETING a supplier: Right click a supplier and select \"Delete\" in the drop down menu. NOTE: This action is irreversible.";
            string addContractText = "ADDING a supplier: Click the \"Add supplier\" button in the top right to add a new supplier.\n\n";
            string sortText = "SORTING suppliers: Click on the column headers to sort the suppliers by that column.\n\n";
            string helpText = introText + editText + deleteText + addContractText + sortText;
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Suppliers_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_form.Show();
        }

        private void TSMIdelete_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (selectedItem != null)
            {
                // Display a warning message
                var result = MessageBox.Show("This is irreversible. Are you sure you want to delete this contract?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Remove the contract from the list and the list view
                    //businessesStub.removeBusiness(businessesStub.getBusinessByName(selectedItem.SubItems[1].Text).GetId());
                    DataAccess.DeleteBusiness(DataAccess.GetBusinessByName(selectedItem.SubItems[1].Text).GetId());
                    SuppliersListLV.Items.Remove(selectedItem);
                }
            }
        }

        private void AddSupplierBTN_Click(object sender, EventArgs e)
        {
            // Load the Add Supplier Popup
            try
            {
                //AddSupplierPopUp_Form addSupplierForm = new AddSupplierPopUp_Form(this, businessesStub);
                AddSupplierPopUp_Form addSupplierForm = new AddSupplierPopUp_Form(this);
                addSupplierForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the Add Contract Popup. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper Methods
        // Fill the list view with businesses
        private void FillSupplierLV(ListView listView)
        {
            //List<Business> businessList = businessesStub.getBusinessses();
            List<Business> businessList = DataAccess.GetAllBusinesses();

            // Loop through the businesses and add them to the list view
            foreach (Business business in businessList)
            {
                ListViewItem businessItem = LVItemCreator(business);
                listView.Items.Add(businessItem);
            }
        }

        // Create a list view item
        private ListViewItem LVItemCreator(Business business)
        {

            ListViewItem businessItem = new ListViewItem(business.GetId().ToString());
            businessItem.SubItems.Add(business.GetName());
            businessItem.SubItems.Add(business.GetAddress());
            businessItem.SubItems.Add(business.GetEmail());
            businessItem.SubItems.Add(FormatPhoneNumber(business.GetPhoneNumber()));


            return businessItem;
        }

        // Add a single business to the list view
        public void AddBusiness(Business businessData)
        {
            //businessesStub.addBusiness(businessData);
            DataAccess.AddBusiness(businessData);
            ListViewItem newContract = LVItemCreator(businessData);
            SuppliersListLV.Items.Add(newContract);
        }

        // Edit a contract in the list view
        public void EditBusiness(Business businessData)
        {
            // Loop through the list view items and update the business
            foreach (ListViewItem listViewItem in SuppliersListLV.Items)
            {
                // Check if the business is the one to be edited
                if (listViewItem.SubItems[0].Text == businessData.GetId().ToString())
                {
                    listViewItem.SubItems[1].Text = businessData.GetName();
                    listViewItem.SubItems[2].Text = businessData.GetAddress();
                    listViewItem.SubItems[3].Text = businessData.GetEmail();
                    listViewItem.SubItems[4].Text = FormatPhoneNumber(businessData.GetPhoneNumber());

                }
            }
        }

        // Format phone number
        private string FormatPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                return string.Format("({0}) {1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));
            }
            return phoneNumber;
        }
    }
}
