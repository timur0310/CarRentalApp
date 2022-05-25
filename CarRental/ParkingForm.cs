using System;
using System.Windows.Forms;

namespace CarRental
{
    public partial class ParkingForm : Form
    {
        public ParkingForm()
        {
            InitializeComponent();
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = long.TryParse(tbRow.Text, out long row) && !string.IsNullOrWhiteSpace(tbNotes.Text);
        }
    }
}
