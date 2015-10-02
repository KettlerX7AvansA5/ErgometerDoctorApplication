using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConClientData : Panel
    {
        public ConClientData() : base()
        {
            // 
            // ConClientData
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConClientData";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;

            this.BackColor = System.Drawing.Color.Red;
        }
    }
}
