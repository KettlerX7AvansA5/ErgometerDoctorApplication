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
    public partial class SessionWindow : Form
    {

        private bool ActiveSession { get; }
        private string ClientName { get; set; }
        public int Session { get; }

        public SessionWindow(string ClientName, bool ActiveSessionm, int session)
        {
            this.ActiveSession = ActiveSession;
            this.ClientName = ClientName;
            Session = session;
            InitializeComponent();

            Form.CheckForIllegalCrossThreadCalls = false;
        }

        public void ClientApplicatie_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Size.Width < 980)
            {
                panelGraphView.Visible = false;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Fill;
            }
            if (control.Size.Width >= 980 && control.Size.Width < 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 250;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }
            if (control.Size.Width >= 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }
        }
    }
}
