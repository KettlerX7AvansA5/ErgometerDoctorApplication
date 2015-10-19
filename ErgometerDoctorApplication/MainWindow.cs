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
        private bool request;

        public MainWindow()
        {
            InitializeComponent();
            conPanelLogin.BringToFront();
            request = false;
            //updateTimer.Start();
            
        }

        private void BtnActiveSessions_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Actieve Sessies";
            conActiveSessions.BringToFront();
            //conActiveSessions.data.Rows.Clear();

            if(MainClient.activesessions.Count > 0)
            {
                conActiveSessions.labelActiveSessions.Text = "";
                conActiveSessions.updateActiveSessions(MainClient.activesessions);
            }
            else
            {
                conActiveSessions.labelActiveSessions.Text = "Er zijn geen actieve sessies.";
            }

            /*
                str += client.Value + ", ";
                MainClient.StartNewCLient(client.Value, client.Key);
                conActiveSessions.data.Rows.Add(client.Value, client.Key);

            //conActiveSessions.labelActiveSessions.Text = str;
            Console.WriteLine(str);
            */
        }

        private void BtnClientData_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Clientenbestand";
            conClientData.BringToFront();

            if (MainClient.users.Count > 0)
            {
                conClientData.updateUsers(MainClient.users);
            }
        }

        private void BtnSessionHistory_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Sessie geschiedenis";
            conSessionHistory.BringToFront();

            MainClient.StartOldCLient("Test", 2001739555);
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
            if (request)
                MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.USERS, MainClient.Session));
            else
                MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.SESSIONDATA, MainClient.Session));

            request = !request;
        }
    }
}
