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
        public ConActiveSessions() : base()
        {
            this.data = new DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.SuspendLayout();
            // 
            // SongsTableView
            // 
            this.data.AllowUserToAddRows = false;
            this.data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name, this.sessionId});
            this.data.AllowUserToDeleteRows = false;
            this.data.AllowUserToResizeRows = false;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Location = new System.Drawing.Point(0, 0);
            this.data.MultiSelect = false;
            this.data.Name = "Active Sessions";
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data.Size = new System.Drawing.Size(760, 172);
            this.data.TabIndex = 0;
            this.data.CellContentClick += new DataGridViewCellEventHandler(this.data_CellContentClick);
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "Name";
            // 
            // sessionId
            // 
            this.sessionId.HeaderText = "Session ID";
            this.sessionId.Name = "Session ID";
            // 
            // ConActiveSessions
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConActiveSessions";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;
            this.Controls.Add(data);
        }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data.Rows[e.RowIndex].Cells[1].Value != null)
            {
                MainClient.StartNewCLient(data.Rows[e.RowIndex].Cells[0].Value + "", int.Parse(data.Rows[e.RowIndex].Cells[1].Value + ""));
            }
        }

        public System.Windows.Forms.DataGridViewTextBoxColumn name;
        public System.Windows.Forms.DataGridViewTextBoxColumn sessionId;
        public System.Windows.Forms.DataGridView data;
    }
}
