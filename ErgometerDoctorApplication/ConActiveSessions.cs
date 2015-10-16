using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConActiveSessions : Panel
    {

        public ConActiveSessions() : base()
        {
            this.labelActiveSessions = new System.Windows.Forms.Label();
            // 
            // ConActiveSessions
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConActiveSessions";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;
            // 
            // labelActiveSessions
            // 
            this.labelActiveSessions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelActiveSessions.AutoSize = true;
            this.labelActiveSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActiveSessions.Location = new System.Drawing.Point(0, 0);
            this.labelActiveSessions.Name = "labelActiveSessions";
            this.labelActiveSessions.Size = new System.Drawing.Size(103, 21);
            this.labelActiveSessions.TabIndex = 3;
            this.labelActiveSessions.Text = "Geen actieve sessies.";

            this.Controls.Add(labelActiveSessions);
        }

        public System.Windows.Forms.Label labelActiveSessions;
    }
}
