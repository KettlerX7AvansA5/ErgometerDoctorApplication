using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(MainClient.Connect(PasswordTextBox.Text))
            {
                PasswordTextBox.BackColor = System.Drawing.SystemColors.Window;
                Close();
            }
            else
            {
                PasswordTextBox.BackColor = Color.Red;
            }
        }
    }
}
