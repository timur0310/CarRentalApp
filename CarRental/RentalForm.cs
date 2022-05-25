using System;
using System.Windows.Forms;

namespace CarRental
{
    public partial class RentalForm : Form
    {
        public RentalForm()
        {
            InitializeComponent();
        }

        private void tbComboChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = cbClients.SelectedItem != null && cbEmployees.SelectedItem != null;
        }
    }
}
