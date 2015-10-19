using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConActiveSessions : Panel
    {
        public DataGridView data;
        public ConActiveSessions() : base()
        {
            this.data = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.labelActiveSessions = new System.Windows.Forms.Label();
            // 
            // SongsTableView
            // 
            this.data.AllowUserToAddRows = false;
            this.data.AllowUserToDeleteRows = false;
            this.data.AllowUserToResizeRows = false;
            this.data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Location = new System.Drawing.Point(0, 0);
            this.data.MultiSelect = false;
            this.data.Name = "Active Sessions";
            this.data.ReadOnly = true;
            this.data.RowHeadersVisible = false;
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data.Size = new System.Drawing.Size(760, 172);
            this.data.TabIndex = 0;
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
