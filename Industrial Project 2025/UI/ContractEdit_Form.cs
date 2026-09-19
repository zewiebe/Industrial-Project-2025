using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Industrial_Project_2025
{
    internal partial class ContractEdit_Form : Form
    {
        // Attributes
        private Contract contract;
        private ContractsStub contractsStub;
        private BusinessesStub businessesStub;
        private List<string> supplierNames;
        private Contracts_Form contracts_Form;

        // Attributes for the contract, used for comparison
        private string contractSource;
        private string commodity;
        private decimal requested;
        private decimal recieved;
        private decimal cost;
        private string startDate;
        private string endDate;
        private string status;

        // Constructor
        /*        public ContractEdit_Form(ContractsStub contractsStub, BusinessesStub businessesStub, Contract contract, Contracts_Form contracts_Form)
                {
                    InitializeComponent();
                    this.AutoScaleMode = AutoScaleMode.Dpi;

                    this.contract = contract;
                    this.contractsStub = contractsStub;
                    this.businessesStub = businessesStub;
                    this.supplierNames = businessesStub.getBusinessNames();
                    this.contracts_Form = contracts_Form;


                    // Set up the TextBox for autocomplete
                    setUpContractSourceTBAutoComplete(supplierNames);
                    // Set up the ComboBox for commodity selection
                    setUpCommodityCB();
                    // Set up the NumericUpDowns
                    setUpNumericUpDowns();
                    // Set up the DateTimePickers
                    setUpDateTimePickers();
                    // Set up contract status
                    setUpContractStatus();
                }*/

        public ContractEdit_Form(Contract contract, Contracts_Form contracts_Form)
        {
            InitializeComponent();

            this.contract = contract;
            this.supplierNames = DataAccess.GetBusinessNames();
            this.contracts_Form = contracts_Form;

            setUpContractSourceTBAutoComplete(supplierNames);
            setUpCommodityCB();
            setUpNumericUpDowns();
            setUpDateTimePickers();
            setUpContractStatus();
        }

        // Event Handlers
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

            // Enable or disable the form controls based on the toggle
            ContractSourceTB.Enabled = !ContractSourceTB.Enabled;
            contractCommodityCB.Enabled = !contractCommodityCB.Enabled;
            requestedNUD.Enabled = !requestedNUD.Enabled;
            recievedNUD.Enabled = !recievedNUD.Enabled;
            costNUD.Enabled = !costNUD.Enabled;
            startDateTB.Enabled = !startDateTB.Enabled;
            endDateTB.Enabled = !endDateTB.Enabled;
            statusCB.Enabled = !statusCB.Enabled;
        }

        // Save the changes to the contract
        private void doneBTN_Click(object sender, EventArgs e)
        {
            if (!checkInputs())
            {
                return;
            }

            // Create a new contract object with the updated values
            Contract newContract = new Contract();
            newContract.SetContractId(contract.GetContractId());
            newContract.SetCreationDate(contract.GetCreationDate());
            newContract.SetPriceBenchmark(contract.GetPriceBenchmark());
            newContract.SetLate(contract.IsLate());
            //newContract.SetSupplier(businessesStub.getBusinessByName(ContractSourceTB.Text));
            newContract.SetSupplier(DataAccess.GetBusinessByName(ContractSourceTB.Text));
            newContract.SetCommodity((Constants.Commodity)Enum.Parse(typeof(Constants.Commodity), stringToEnum(contractCommodityCB.Text)));
            newContract.SetQuantity((float)requestedNUD.Value);
            newContract.SetPrice((float)costNUD.Value);
            newContract.SetReceived((float)recievedNUD.Value);
            newContract.SetOpen(statusCB.Text == "Open");
            newContract.SetStartDate(DateTime.ParseExact(startDateTB.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture));
            newContract.SetEndDate(DateTime.ParseExact(endDateTB.Text, "MM-dd-yyyy", CultureInfo.InvariantCulture));
         //   newContract.SetStartDate(startDateDTP.Value.Date);
         //   newContract.SetEndDate(endDateDTP.Value.Date);


            if (CompareInputs()) // If changes were made
            {
                // Check if the received amount is greater than or equal to the requested amount and prompt the user to close the contract
                if (recievedNUD.Value >= requestedNUD.Value)
                {
                    var changeOpenStatus = MessageBox.Show("The received amount is greater than or equal to the requested amount. Do you want to close the contract?", "Close Contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (changeOpenStatus == DialogResult.Yes)
                    {
                        statusCB.Text = "Closed";
                        newContract.SetOpen(false);
                    }
                }

                // Prompt the user to confirm the changes
                var confirmResult = MessageBox.Show("Are you sure you want to save the changes?", "Confirm Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    //contractsStub.updateContract(newContract);
                    DataAccess.UpdateContracts(newContract);
                    contracts_Form.EditContract(newContract);

                    this.Hide();
                }
                else // If the user cancels, do not save the changes
                {
                    this.Hide();
                }
            }
            else // If no changes were made, close the form
            {
                this.Hide();
            }
        }

        // Helper Methods
        // Set up the contract source TextBox for autocomplete
        private void setUpContractSourceTBAutoComplete(List<string> supplierNames)
        {
            ContractSourceTB.AutoCompleteMode = AutoCompleteMode.Suggest;
            ContractSourceTB.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
            autoCompleteData.AddRange(supplierNames.ToArray()); // Convert List<string> to string[]
            ContractSourceTB.AutoCompleteCustomSource = autoCompleteData;

            ContractSourceTB.Text = contract.GetSupplier().GetName();
            contractSource = contract.GetSupplier().GetName();
        }

        // Set up the commodity ComboBox
        private void setUpCommodityCB()
        {
            String[] commodities = Enum.GetNames(typeof(Constants.Commodity));
            for (int i = 0; i < commodities.Length; i++)
            {
                commodities[i] = enumToString((Constants.Commodity)i);
            }


            contractCommodityCB.DataSource = commodities;

            contractCommodityCB.SelectedItem = enumToString(contract.GetCommodity());
            commodity = enumToString(contract.GetCommodity());
        }

        // Set up the NumericUpDowns
        private void setUpNumericUpDowns()
        {
            requested = (decimal)contract.GetQuantity();
            recieved = (decimal)contract.GetReceived();
            cost = (decimal)contract.GetPrice();

            requestedNUD.Value = requested;
            recievedNUD.Value = recieved;
            costNUD.Value = cost;
        }

        // Set up the DateTimePickers
        private void setUpDateTimePickers()
        {
            startDateTB.Text = contract.GetStartDate().ToString("MM-dd-yyyy");
            endDateTB.Text = contract.GetEndDate().ToString("MM-dd-yyyy");

            startDate = contract.GetStartDate().ToString("MM-dd-yyyy");
            endDate = contract.GetEndDate().ToString("MM-dd-yyyy");
        }

        // Set up the contract status ComboBox
        private void setUpContractStatus()
        {
            if (contract.IsOpen())
            {
                statusCB.Text = "Open";
            }
            else
            {
                statusCB.Text = "Closed";
            }

            status = statusCB.Text;
        }

        // Check if the date is in the correct format
        private bool IsValidDateFormat(string dateString)
        {
            string format = "MM-dd-yyyy"; 
            DateTime date;
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        // Check if the inputs are valid
        private bool checkInputs()
        {
            /*if (businessesStub.getBusinessByName(ContractSourceTB.Text) == null)
            {
                MessageBox.Show("Please enter a valid supplier name from the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/
            if (DataAccess.GetBusinessByName(ContractSourceTB.Text) == null)
            {
                MessageBox.Show("Please enter a valid supplier name from the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsValidDateFormat(startDateTB.Text) || !IsValidDateFormat(endDateTB.Text))
            {
                MessageBox.Show("Invalid date format. Please enter the date in MM-DD-YYYY format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Compare the inputs to the original contract
        private bool CompareInputs()
        {
            bool changed = false;

            if (contractSource != ContractSourceTB.Text || commodity != contractCommodityCB.Text || requested != requestedNUD.Value || recieved != recievedNUD.Value || cost != costNUD.Value || startDate != startDateTB.Text || endDate != endDateTB.Text || status != statusCB.Text)
            {
                changed = true;
            }

            return changed;
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

        private String stringToEnum(string commodity)
        {
            switch (commodity)
            {
                case "Corn":
                    return "Corn";
                case "Wheat":
                    return "Wheat";
                case "Soybean Meal":
                    return "Soybean_Meal";
                case "Canola Meal":
                    return "Canola_Meal";
                default:
                    throw new ArgumentException("Invalid commodity string");
            }
        }
    }
}
