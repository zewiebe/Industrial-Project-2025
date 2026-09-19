using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Industrial_Project_2025.Constants;

namespace Industrial_Project_2025
{
    internal partial class AddContractPopUp_Form : Form
    {
        // Attributes
        private List<string> supplierNames;
        private Contracts_Form contracts_form;
        private ContractsStub contractsStub;
        private BusinessesStub businessesStub;
        private int stage = 0;
        private DateTime contractStartDate;
        private DateTime contractEndDate;
        private bool startDateSelected = false;
        private bool endDateSelected = false;
        private List<Contract> contractList;

        // Constructor
/*        public AddContractPopUp_Form(ContractsStub contractsStub, BusinessesStub businessesStub, Contracts_Form contracts_Form)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

            this.supplierNames = businessesStub.getBusinessNames();
            this.contracts_form = contracts_Form;
            this.contractsStub = contractsStub;
            this.businessesStub = businessesStub;

            // Set up the TextBox for autocomplete
            setUpContractSourceTBAutoComplete(supplierNames);
            // Set up the ComboBox for commodity selection
            setUpCommodityCB();
        }*/

        public AddContractPopUp_Form(Contracts_Form contracts_Form)
        {
            InitializeComponent();
            this.contracts_form = contracts_Form;
            this.supplierNames = DataAccess.GetBusinessNames();
            this.contractList = DataAccess.GetAllContracts();

            // Set up the TextBox for autocomplete
            setUpContractSourceTBAutoComplete(supplierNames);
            // Set up the ComboBox for commodity selection
            setUpCommodityCB();
        }

        // Event Handlers
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Check if the user has selected a start date
            if (!endDateSelected)
            {
                MessageBox.Show("Please select an end date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contract newContract = new Contract();

            // Set the new contract's attributes
            //newContract.SetContractId(contractsStub.getContractCount() + 1);
            newContract.SetContractId(contractList.Count + 1);
            //newContract.SetSupplier(businessesStub.getBusinessByName(ContractSourceTB.Text));
            newContract.SetSupplier(DataAccess.GetBusinessByName(ContractSourceTB.Text));
            newContract.SetCommodity((Constants.Commodity)Enum.Parse(typeof(Constants.Commodity), ContractCommodityCB.Text));
            newContract.SetQuantity((float)AmountBoughtNUP.Value);
            newContract.SetPrice((float)totalCostNUD.Value);
            newContract.SetReceived((float)(AmountReceivedNUP.Value));
            newContract.SetOpen(true);
            newContract.SetCreationDate(DateTime.Now);
            newContract.SetStartDate(contractStartDate);
            newContract.SetEndDate(contractEndDate);


            // Add the new contract to the contracts listview
            contracts_form.AddContract(newContract);

            this.Hide();
        }

        // Next button
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (stage == 0) // Stage 0 of the form
            {
                // Check if the user has entered a valid business
                /* if (businessesStub.getBusinessByName(ContractSourceTB.Text) == null)
                {
                    MessageBox.Show("Please enter a valid supplier name from the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                if (DataAccess.GetBusinessByName(ContractSourceTB.Text) == null)
                {
                    MessageBox.Show("Please enter a valid supplier name from the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the user has entered a valid commodity
                if (AmountBoughtNUP.Value == 0)
                {
                    MessageBox.Show("Please enter a valid amount bought.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Display the next stage of the form
                contractStartDateL.Visible = true;
                CALcontractStartDate.Visible = true;
                ContractSourceTB.Visible = false;
                ContractCommodityCB.Visible = false;
                AmountBoughtNUP.Visible = false;
                totalCostNUD.Visible = false;
                AmountReceivedNUP.Visible = false;
                CommodityChoiceL.Visible = false;
                ContractAmountL.Visible = false;
                TotalCostL.Visible = false;
                AmountReceivedL.Visible = false;

                stage++;
            }

            else if (stage == 1) // Stage 1 of the form
            {
                // Check if the user has selected a start date
                if (!startDateSelected)
                {
                    MessageBox.Show("Please select a start date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Display the next stage of the form
                contractStartDateL.Visible = false;
                CALcontractStartDate.Visible = false;
                contractEndDateL.Visible = true;
                CALcontractEndDate.Visible = true;
                nextButton.Visible = false;
                saveButton.Visible = true;

                stage++;
            }
        }

        // Back button
        private void backButton_Click(object sender, EventArgs e)
        {
            if (stage == 0) // If the user is on the first stage of the form, close the form
            {
                this.Hide();
            }
            else if (stage == 1) // stage 1 of the form
            {
                // Display the previous stage of the form
                contractStartDateL.Visible = false;
                CALcontractStartDate.Visible = false;
                ContractSourceTB.Visible = true;
                ContractCommodityCB.Visible = true;
                AmountBoughtNUP.Visible = true;
                totalCostNUD.Visible = true;
                AmountReceivedNUP.Visible = true;
                CommodityChoiceL.Visible = true;
                ContractAmountL.Visible = true;
                TotalCostL.Visible = true;
                AmountReceivedL.Visible = true;

                stage--;
            }
            else if (stage == 2) // stage 2 of the form
            {
                // Display the previous stage of the form
                contractStartDateL.Visible = true;
                CALcontractStartDate.Visible = true;
                contractEndDateL.Visible = false;
                CALcontractEndDate.Visible = false;
                nextButton.Visible = true;
                saveButton.Visible = false;

                stage--;
            }
        }

        // Date Selected Event Handlers
        private void CALcontractStartDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            contractStartDate = e.Start; // Set the contract start date
            startDateSelected = true;
        }

        private void CALcontractEndDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            contractEndDate = e.Start;
            endDateSelected = true;
        }

        // Helper Methods
        private void setUpContractSourceTBAutoComplete(List<string> supplierNames)
        {
            // Set up the TextBox for autocomplete
            ContractSourceTB.AutoCompleteMode = AutoCompleteMode.Suggest;
            ContractSourceTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(supplierNames.ToArray()); // Convert List<string> to string[]
            ContractSourceTB.AutoCompleteCustomSource = autoCompleteData;
        }

        // Set up the ComboBox for commodity selection
        private void setUpCommodityCB()
        {
            ContractCommodityCB.DataSource = Enum.GetValues(typeof(Constants.Commodity));
        }
    }
}
