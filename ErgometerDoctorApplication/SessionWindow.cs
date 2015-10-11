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
        public SessionWindow(string ClientName, bool ActiveSession)
        {
            this.ActiveSession = ActiveSession;
            this.ClientName = ClientName;
            InitializeComponent();
        }
    }
}
