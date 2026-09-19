using static System.Net.Mime.MediaTypeNames;

namespace Industrial_Project_2025
{
    public partial class Home_Form : Form
    {
        private Contracts_Form contractsForm;
        private Suppliers_Form Suppliers_Form;
        private ContractColumnSorter lvwColumnSorter;
        private readonly TextBox txt = new TextBox { BorderStyle = BorderStyle.FixedSingle, Visible = false };
        private ContractsStub contractsStub = new ContractsStub();
        private List<Contract> contractList;

        public Home_Form()
        {
            InitializeComponent();


            contractList = DataAccess.GetAllContracts();
            //contractList = contractsStub.getContracts();

            contractsForm = new Contracts_Form(this);
            Suppliers_Form = new Suppliers_Form(this);
            lvwColumnSorter = new ContractColumnSorter(); // Create an instance of a ListView column sorter and assign it to the ListView control.
            this.endingContractsLV.ListViewItemSorter = lvwColumnSorter; // Set the ListView column sorter to the ListView control.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up the ListView
            endingContractsLV.View = View.Details;
            endingContractsLV.Controls.Add(txt);
            endingContractsLV.FullRowSelect = true;
            txt.Leave += (o, e) => txt.Visible = false;

            // Add columns
            endingContractsLV.Columns.Add("Name");
            endingContractsLV.Columns.Add("Commodity");
            endingContractsLV.Columns.Add("End Date");
            endingContractsLV.Columns.Add("Amount Bought (kg)");
            endingContractsLV.Columns.Add("Price ($)");

            // Fill the list view
            FillContractListView();

            // Set the column to sort by End Date column (which is the third column, index 2)
            lvwColumnSorter.SortColumn = 2;
            lvwColumnSorter.Order = SortOrder.Ascending;

            // Perform the sort
            endingContractsLV.Sort();

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.endingContractsLV.Columns)
            {
                ch.Width = -2;
            }
        }

        private void contract_screen_open_button_Click(object sender, EventArgs e)
        {
            contractsForm.Show();
            this.Hide();
        }

        private void supplier_screen_open_button_Click(object sender, EventArgs e)
        {
            Suppliers_Form.Show();
            this.Hide();
        }

        //go to price view
        private void button1_Click(object sender, EventArgs e)
        {
            PriceView price_view = new PriceView(this);
            price_view.Show();
            //this.Hide();
        }


        private void endingContractsLV_ColumnClick_1(object sender, ColumnClickEventArgs e)
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
            this.endingContractsLV.Sort();
        }

        // Fill the list view with contracts that are ending this week
        private void FillContractListView()
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);

            

            // Loop through contracts and add them to the list view if they are ending this week
            foreach (Contract contract in contractList)
            {
                DateTime endDate = contract.GetEndDate();
                if (endDate >= startOfWeek && endDate <= endOfWeek && contract.IsOpen()) // Only show contracts that are open
                {
                    ListViewItem contractItem = LVItemCreator(contract);
                    endingContractsLV.Items.Add(contractItem);
                }
            }
        }

        // Create a list view item
        private ListViewItem LVItemCreator(Contract contract)
        {

            ListViewItem contractItem = new ListViewItem(contract.GetSupplier().GetName());
            contractItem.SubItems.Add(enumToString(contract.GetCommodity()));
            contractItem.SubItems.Add(contract.GetEndDate().ToShortDateString());
            contractItem.SubItems.Add(contract.GetQuantity().ToString());
            contractItem.SubItems.Add(contract.GetPrice().ToString("C2"));

            return contractItem;
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
