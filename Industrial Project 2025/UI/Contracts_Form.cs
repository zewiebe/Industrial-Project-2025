using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Industrial_Project_2025
{
    internal partial class Contracts_Form : Form
    {
        // Variables
        private Home_Form home_form;
        private readonly TextBox txt = new TextBox { BorderStyle = BorderStyle.FixedSingle, Visible = false };
        private ContractColumnSorter lvwColumnSorter;
        private ContractsStub contractsStub = new ContractsStub();
        private BusinessesStub businessesStub = new BusinessesStub();
        private List<Contract> contractList;
        private List<Business> businessList;
        private ListViewItem selectedItem = null;


        // Form
        public Contracts_Form(Home_Form home_form)
        {
            InitializeComponent();

            this.contractList = DataAccess.GetAllContracts();
            //this.contractList = contractsStub.getContracts();

            lvwColumnSorter = new ContractColumnSorter(); // Create an instance of a ListView column sorter and assign it to the ListView control.
            this.contract_List_View.ListViewItemSorter = lvwColumnSorter; // Set the ListView column sorter to the ListView control.

            this.home_form = home_form;
        }

        // Event Handlers
        private void Contracts_Form_Load(object sender, EventArgs e)
        {
            // Set up the ListView
            contract_List_View.View = View.Details;
            contract_List_View.Controls.Add(txt);
            contract_List_View.FullRowSelect = true;
            txt.Leave += (o, e) => txt.Visible = false;

            // Add columns
            contract_List_View.Columns.Add("ID");
            contract_List_View.Columns.Add("Name");
            contract_List_View.Columns.Add("Commodity");
            contract_List_View.Columns.Add("Amount Requested (kg)");
            contract_List_View.Columns.Add("Amount Recieved (kg)");
            contract_List_View.Columns.Add("Amount Remaining (kg)");
            contract_List_View.Columns.Add("Cost (CAD)");
            contract_List_View.Columns.Add("Start Date");
            contract_List_View.Columns.Add("End Date");
            contract_List_View.Columns.Add("Status");

            FillContractListView(contract_List_View);
            updateLateContractsMarker(); // Update the late contracts parameter

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.contract_List_View.Columns)
            {
                ch.Width = -2;
            }
        }

        // Double click to add to existing load amount
        private void contract_List_View_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = contract_List_View.HitTest(e.Location); // Get the location of the mouse click

            // Create a textbox to allow the user to input a new value
            Rectangle rowBounds = hit.SubItem.Bounds;
            Rectangle labelBounds = hit.Item.GetBounds(ItemBoundsPortion.Label);
            int leftMargin = labelBounds.Left - 6;
            txt.Bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, rowBounds.Width - leftMargin - 1, rowBounds.Height);
            if (hit.Item.SubItems.IndexOf(hit.SubItem) == hit.Item.SubItems.Count - 6) // check if the subitem is the last one
            {
                // Check if the user has clicked on the "Amount Recieved" column
                string input = Microsoft.VisualBasic.Interaction.InputBox("ADD to existing load amount:", "Add to load amount", hit.SubItem.Text);
                if (!string.IsNullOrEmpty(input))
                {
                    // Update the value of the amount recieved
                    double loadAmount = convertToDouble(input);
                    double amountRecieved = convertToDouble(hit.SubItem.Text);
                    hit.SubItem.Text = (amountRecieved + loadAmount).ToString();

                    //contractsStub.getContractById(Convert.ToInt32(hit.Item.SubItems[0].Text)).SetReceived(Convert.ToInt32(hit.SubItem.Text)); // Update the contract object
                    DataAccess.GetContract(Convert.ToInt32(hit.Item.SubItems[0].Text)).SetReceived(Convert.ToInt32(hit.SubItem.Text));
                    updateAmountRemaining(hit.Item); // Update the amount remaining
                    updateStatus(); // Update the status of the contract
                    RecolourContracts(); // Recolour the contracts
                }
            }
        }

        // Right click to view/edit or delete a contract
        private void contract_List_View_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Check if an item was clicked
                var focusedItem = contract_List_View.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    selectedItem = focusedItem;
                    CMSlistView.Show(Cursor.Position); // Show the context menu
                    if (selectedItem.SubItems[9].Text == "Closed")
                    {
                        TSMIclose.Text = "Open contract";
                    }
                    else
                    {
                        TSMIclose.Text = "Close contract";
                    }
                }
            }
        }

        // Sort the contracts by column
        private void contract_List_View_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.contract_List_View.Sort();
        }

        // Help button
        private void HelpButton_Click(object sender, EventArgs e)
        {
            string introText = "There are a number of functions available from this page, below is a short intro to each:\n\n";
            string addText = "ADDING to current value: Double click the contract's value underneath the \"Amount Recieved\" column.\n\n";
            string deleteText = "DELETING a contract: Right click a contract and select \"Delete\" in the drop down menu. NOTE: This action is irreversible.";
            string editText = "EDITING a contract: Right click a contract and selected \"View/Edit\" in the drop down menu. NOTE: You cannot undo this without repeating steps, the old values are not stored.\n\n";
            string openCloseText = "OPENING/CLOSING a contract: Right click a contract and select \"Open contract\" or \"Close contract\" in the drop down menu.\n\n";
            string addContractText = "ADDING a contract: Click the \"Add Contract\" button in the top right to add a new contract.\n\n";
            string sortText = "SORTING contracts: Click on the column headers to sort the contracts by that column.\n\n";
            string colourCodeText = "COLOUR CODE: Contracts are colour coded based on their status. Green = Closed, Yellow = Open, Red = Late. Click the colour coordination checkbox to coloour the rows\n\n";
            string helpText = introText + addText + deleteText + editText + openCloseText + addContractText + sortText + colourCodeText;
            MessageBox.Show(helpText, "Contract Page Controls", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Add contract button
        private void Add_Contract_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //AddContractPopUp_Form addContractPopup = new AddContractPopUp_Form(contractsStub, businessesStub, this);
                AddContractPopUp_Form addContractPopup = new AddContractPopUp_Form(this);
                addContractPopup.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the Add Contract Popup. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Contract checkbox
        private void ContractCheckBox_Click(object sender, EventArgs e)
        {
            bool isChecked = ContractCheckBox.Checked;

            RecolourContracts();
        }

        // Form closing
        private void Contracts_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Back button
        private void contracts_Form_Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_form.Show();
        }

        // Context menu strip (Delete)
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
                    //contractsStub.removeContract(contractsStub.getContractById(Convert.ToInt32(selectedItem.SubItems[0].Text)));
                    DataAccess.DeleteContracts(Convert.ToInt32(selectedItem.SubItems[0].Text));
                    contract_List_View.Items.Remove(selectedItem);
                    RecolourContracts();
                }
            }
        }

        // Context menu strip (Edit)
        private void TSMIedit_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (selectedItem != null)
            {
                try
                {
                    // Load the contract editor page
                    //Contract contract = contractsStub.getContractById(Convert.ToInt32(selectedItem.SubItems[0].Text));
                    Contract contract = DataAccess.GetContract(Convert.ToInt32(selectedItem.SubItems[0].Text));
                    //ContractEdit_Form editContract = new ContractEdit_Form(contractsStub, businessesStub, contract, this);
                    ContractEdit_Form editContract = new ContractEdit_Form(contract, this);
                    editContract.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load the contract editor page. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TSMIclose_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (selectedItem != null)
            {
                if (selectedItem.SubItems[9].Text == "Closed")
                {
                    // Open the contract
                    //contractsStub.getContractById(Convert.ToInt32(selectedItem.SubItems[0].Text)).SetOpen(true);
                    DataAccess.GetContract(Convert.ToInt32(selectedItem.SubItems[0].Text)).SetOpen(true);
                    selectedItem.SubItems[9].Text = "Open";
                    RecolourContracts();
                }
                else
                {
                    // Close the contract
                    //contractsStub.getContractById(Convert.ToInt32(selectedItem.SubItems[0].Text)).SetOpen(false);
                    DataAccess.GetContract(Convert.ToInt32(selectedItem.SubItems[0].Text)).SetOpen(false);
                    selectedItem.SubItems[9].Text = "Closed";

                    string endDate = selectedItem.SubItems[8].Text;
                    DateTime endDateTime = Convert.ToDateTime(endDate);
                    endDateTime = endDateTime.Date;

                    if (endDateTime <= DateTime.Now.Date)
                        //businessesStub.getBusinessByName(selectedItem.SubItems[1].Text).AddRating(1);
                        DataAccess.GetBusinessByName(selectedItem.SubItems[1].Text).AddRating(1);
                    else
                        //businessesStub.getBusinessByName(selectedItem.SubItems[1].Text).AddRating(0);
                        DataAccess.GetBusinessByName(selectedItem.SubItems[1].Text).AddRating(0);


                    RecolourContracts();
                }
            }
        }

        // Methods
        // Fill the list view with contracts
        private void FillContractListView(ListView listView)
        {
            //List<Contract> contractsList = contractsStub.getContracts();
            List<Contract> contractsList = DataAccess.GetAllContracts();

            // Loop through the contracts and add them to the list view
            foreach (Contract contract in contractsList)
            {
                ListViewItem contractItem = LVItemCreator(contract);
                listView.Items.Add(contractItem);
            }
        }

        // Add a single contract to the list view
        public void AddContract(Contract contractData)
        {
            //contractsStub.addContract(contractData);
            DataAccess.AddContract(contractData);
            ListViewItem newContract = LVItemCreator(contractData);
            contract_List_View.Items.Add(newContract);

            RecolourContracts();
        }

        // Create a list view item
        private ListViewItem LVItemCreator(Contract contract)
        {

            ListViewItem contractItem = new ListViewItem(contract.GetContractId().ToString());
            contractItem.SubItems.Add(contract.GetSupplier().GetName());
            contractItem.SubItems.Add(enumToString(contract.GetCommodity()));
            contractItem.SubItems.Add(contract.GetQuantity().ToString());
            contractItem.SubItems.Add(contract.GetReceived().ToString());
            contractItem.SubItems.Add((contract.GetQuantity() - contract.GetReceived()).ToString());
            contractItem.SubItems.Add(contract.GetPrice().ToString());
            contractItem.SubItems.Add(contract.GetStartDate().ToShortDateString());
            contractItem.SubItems.Add(contract.GetEndDate().ToShortDateString());
            contractItem.SubItems.Add(contract.IsOpen() ? "Open" : "Closed");

            return contractItem;
        }

        // Edit a contract in the list view
        public void EditContract(Contract contractData)
        {
            // Loop through the list view items and update the contract
            foreach (ListViewItem listViewItem in contract_List_View.Items)
            {
                if (listViewItem.SubItems[0].Text == contractData.GetContractId().ToString())
                {
                    listViewItem.SubItems[1].Text = contractData.GetSupplier().GetName();
                    listViewItem.SubItems[2].Text = contractData.GetCommodity().ToString();
                    listViewItem.SubItems[3].Text = contractData.GetQuantity().ToString();
                    listViewItem.SubItems[4].Text = contractData.GetReceived().ToString();
                    listViewItem.SubItems[5].Text = (contractData.GetQuantity() - contractData.GetReceived()).ToString();
                    listViewItem.SubItems[6].Text = contractData.GetPrice().ToString();
                    listViewItem.SubItems[7].Text = contractData.GetStartDate().ToShortDateString();
                    listViewItem.SubItems[8].Text = contractData.GetEndDate().ToShortDateString();
                    listViewItem.SubItems[9].Text = contractData.IsOpen() ? "Open" : "Closed";
                }
            }

            // Update contract and recolour the listview
            updateLateContractsMarker();
            RecolourContracts();
        }

        // Recolour the contracts in the list view
        private void RecolourContracts()
        {
            // Check if the checkbox is checked
            bool isChecked = ContractCheckBox.Checked;
            if (isChecked)
            {
                // Loop through the contracts and recolour them based on their status
                for (int i = 0; i < contract_List_View.Items.Count; i++)
                {
                    string endDate = contract_List_View.Items[i].SubItems[8].Text;
                    DateTime endDateTime = Convert.ToDateTime(endDate);
                    endDateTime = endDateTime.Date;

                    DateTime currentDateTime = DateTime.Now.Date;
                    //Contract contract = contractsStub.getContractById(i + 1);
                    Contract contract = DataAccess.GetContract(i + 1);

                    int dateCompare = DateTime.Compare(currentDateTime, endDateTime);

                    // Check if the contract is late
                    if (contract != null && contract.IsLate())
                    {
                        contract_List_View.Items[i].BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        // Check if the contract is closed
                        if (convertToDouble(contract_List_View.Items[i].SubItems[5].Text) <= 0 || contract_List_View.Items[i].SubItems[9].Text == "Closed")
                        {
                            contract_List_View.Items[i].BackColor = Color.LightGreen;
                        }
                        // Check if the contract is late
                        else if (convertToDouble(contract_List_View.Items[i].SubItems[5].Text) > 0 && dateCompare > 0)
                        {
                            contract_List_View.Items[i].BackColor = Color.LightSalmon;
                        }
                        // Contract not done yet, but not late
                        else if (convertToDouble(contract_List_View.Items[i].SubItems[5].Text) > 0 && dateCompare <= 0 )
                        {
                            contract_List_View.Items[i].BackColor = Color.LightGoldenrodYellow;
                        }
                    }

                }
                // Resize the columns
                for (int i = 0; i < contract_List_View.Columns.Count; i++)
                {
                    contract_List_View.Columns[i].Width = -2;
                }
            }

            else
            {
                // Loop through the contracts and recolour them based on their status
                for (int i = 0; i < contract_List_View.Items.Count; i++)
                {
                    contract_List_View.Items[i].BackColor = Color.White;
                }
                // Resize the columns
                for (int i = 0; i < contract_List_View.Columns.Count; i++)
                {
                    contract_List_View.Columns[i].Width = -2;
                }
            }
        }

        // Update the status of the contracts
        private void updateStatus()
        {
            for (int i = 0; i < contract_List_View.Items.Count; i++)
            {
                if (contract_List_View.Items[i].SubItems[5].Text == "0")
                {
                    contract_List_View.Items[i].SubItems[9].Text = "Closed";
                    //contractsStub.getContractById(i + 1).SetOpen(false);
                    DataAccess.GetContract(i + 1).SetOpen(false);
                }
            }
        }

        // Update the amount remaining of a contract
        private void updateAmountRemaining(ListViewItem contractItem)
        {
            double amountRequested = convertToDouble(contractItem.SubItems[3].Text);
            double amountReceived = convertToDouble(contractItem.SubItems[4].Text);
            contractItem.SubItems[5].Text = (amountRequested - amountReceived).ToString();
        }

        // Update the late contracts marker
        private void updateLateContractsMarker()
        {
            //List<Contract> contractsList = contractsStub.getContracts();
            List<Contract> contractsList = DataAccess.GetAllContracts();

            foreach (var contract in contractsList)
            {
                if (contract.GetEndDate() < DateTime.Now.Date && contract.GetReceived() < contract.GetQuantity())
                {
                    contract.SetLate(true);
                }
            }
        }

        // Convert text to integer
        private double convertToDouble(string text)
        {
            double result;
            if (double.TryParse(text, out result))
            {
                return result;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
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