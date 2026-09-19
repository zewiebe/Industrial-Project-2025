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
    internal partial class AddSupplierPopUp_Form : Form
    {
        // Attributes
        private Suppliers_Form suppliers_form;
        private BusinessesStub businessesStub;

        // Constructor
/*        public AddSupplierPopUp_Form(Suppliers_Form suppliers_form, BusinessesStub businessesStub)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.suppliers_form = suppliers_form;
            this.businessesStub = businessesStub;
        }*/

        public AddSupplierPopUp_Form(Suppliers_Form suppliers_form)
        {
            InitializeComponent();
            this.suppliers_form = suppliers_form;

        }

        // Event Handlers
        private void backBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            // Check if the input is valid
            if (!checkInput())
            {
                return;
            }

            // Create a new business object and send it to the suppliers form
            Business newBusiness = new Business();
            //newBusiness.SetId(businessesStub.getBusinessCount() + 1);
            newBusiness.SetId(DataAccess.GetAllBusinesses().Count + 1);
            newBusiness.SetName(nameTB.Text);
            newBusiness.SetAddress(addressTB.Text);
            newBusiness.SetEmail(emailTB.Text);
            newBusiness.SetPhoneNumber(phoneNumberTB.Text);

            suppliers_form.AddBusiness(newBusiness);

            this.Hide();
        }

        // Methods
        // Check if the input is valid
        private bool checkInput()
        {
            // Check if the name field is empty, it is the only required field
            if (nameTB.Text == "")
            {
                MessageBox.Show("Please fill the fields. At minimum supplier name must be inputted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Check if a supplier with the same name already exists
            /*            if (businessesStub.getBusinessByName(nameTB.Text) != null)
                        {
                            MessageBox.Show("A supplier with this name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }*/
            if (DataAccess.GetBusinessByName(nameTB.Text) != null)
            {
                MessageBox.Show("A supplier with this name already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Check if the phone number and email are valid
            if (!Regex.IsMatch(phoneNumberTB.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Please enter a valid phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(emailTB.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
