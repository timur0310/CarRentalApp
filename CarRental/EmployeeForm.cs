using System;
using System.Windows.Forms;

namespace CarRental
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbLastName.Text) &&
                !string.IsNullOrWhiteSpace(tbFirstName.Text) &&
                !string.IsNullOrWhiteSpace(tbSecondName.Text) &&
                DateTime.TryParse(tbAppointmentDate.Text, out DateTime dt) &&
                !string.IsNullOrWhiteSpace(tbAddress.Text) &&
                !string.IsNullOrWhiteSpace(tbPhone.Text);
        }
    }
}
