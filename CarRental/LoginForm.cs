using System;
using System.Windows.Forms;

namespace CarRental
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = cbEmployee.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(tbPassword.Text);
        }
    }
}
