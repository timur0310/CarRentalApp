using System;
using System.Windows.Forms;

namespace CarRental
{
    public partial class BrandForm : Form
    {
        public BrandForm()
        {
            InitializeComponent();
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbName.Text);
        }
    }
}
