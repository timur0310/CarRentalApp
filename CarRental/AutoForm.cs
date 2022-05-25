using System;
using System.Windows.Forms;

namespace CarRental
{
    public partial class AutoForm : Form
    {
        public AutoForm()
        {
            InitializeComponent();
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = decimal.TryParse(tbCost.Text, out decimal cost) && 
                !string.IsNullOrWhiteSpace(tbNumber.Text) &&
                cbBrands.SelectedItem != null && cbParking.SelectedItem != null &&
                DateTime.TryParse(tbRegistryDate.Text, out DateTime dt);
        }
    }
}
