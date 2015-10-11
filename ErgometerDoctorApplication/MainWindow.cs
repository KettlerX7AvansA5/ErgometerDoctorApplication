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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            conPanelLogin.BringToFront();
        }

        private void BtnActiveSessions_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Actieve Sessies";
            conActiveSessions.BringToFront();
        }

        private void BtnSessionLibrary_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Bibliotheek";
            conSessionLibrary.BringToFront();
        }

        private void BtnClientData_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Clientenbestand";
            conClientData.BringToFront();
        }

        private void BtnSessionHistory_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Sessie geschiedenis";
            conSessionHistory.BringToFront();
        }
        public void validateLogin()
        {
            //enter login details
            showDashboard();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //logout
            showLoginScreen();
        }

        private void showDashboard()
        {
            conPanelLogin.Visible = false;
            MainContainer.Visible = true;
            panel1.Visible = true;
            MenuPanel.Visible = true;
            menuStrip1.Visible = true;
        }

        private void showLoginScreen()
        {
            MainContainer.Visible = false;
            panel1.Visible = false;
            MenuPanel.Visible = false;
            menuStrip1.Visible = false;
            conPanelLogin.Visible = true;
            conPanelLogin.BringToFront();
        }
    }
}
