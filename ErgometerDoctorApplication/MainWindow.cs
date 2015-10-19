using ErgometerLibrary;
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
            updateTimer.Start();
        }

        private void BtnActiveSessions_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Actieve Sessies";
            conActiveSessions.BringToFront();

            string str = "";
            foreach(KeyValuePair<int, string> client in MainClient.activesessions)
            {
                str += client.Value + ", ";
                MainClient.StartNewCLient(client.Value, client.Key);
            }
            conActiveSessions.labelActiveSessions.Text = str;
            Console.WriteLine(str);
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
            string error = "";
            bool connect = MainClient.Connect(conPanelLogin.textBoxPassword.Text, out error);

            if (connect)
            {
                conPanelLogin.textBoxPassword.Text = "";
                conPanelLogin.labelLoginInfo.Text = "";
                showDashboard();
            }
            else
            {
                conPanelLogin.labelLoginInfo.Text = error;
                showLoginScreen();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            MainClient.Disconnect();
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

        private void updateTimer_tick(object sender, EventArgs e)
        {
            MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.SESSIONDATA, MainClient.Session));
        }
    }
}
