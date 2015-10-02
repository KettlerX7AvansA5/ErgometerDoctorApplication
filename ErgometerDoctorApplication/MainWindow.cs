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
        }

        private void BtnActiveSessions_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Actieve Sessies";
            conActiveSessions.Visible = true;
            conClientData.Visible = false;
            conSessionHistory.Visible = false;
            conSessionLibrary.Visible = false;
        }

        private void BtnSessionLibrary_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Bibliotheek";
            conActiveSessions.Visible = false;
            conClientData.Visible = false;
            conSessionHistory.Visible = false;
            conSessionLibrary.Visible = true;
        }

        private void BtnClientData_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Clientenbestand";
            conActiveSessions.Visible = false;
            conClientData.Visible = true;
            conSessionHistory.Visible = false;
            conSessionLibrary.Visible = false;
        }

        private void BtnSessionHistory_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Sessie geschiedenis";
            conActiveSessions.Visible = false;
            conClientData.Visible = false;
            conSessionHistory.Visible = true;
            conSessionLibrary.Visible = false;
        }
    }
}
