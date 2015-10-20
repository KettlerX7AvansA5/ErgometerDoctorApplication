using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    class SessionPanel : Panel
    {
        private int Session;
        private string Name;
        private bool IsNew;

        public SessionPanel(int session, string name, bool isNew) : base()
        {

            Session = session;
            Name = name;
            IsNew = isNew;

            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(180, 100);
            this.BackColor = System.Drawing.Color.White;

            this.Click += SessionPanel_Click;
            this.MouseEnter += SessionPanel_MouseEnter;
            this.MouseLeave += SessionPanel_MouseLeave;
            this.Cursor = Cursors.Hand;

            this.labelName = new System.Windows.Forms.Label();

            // 
            // labelActiveSessions
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(10, 10);
            this.labelName.ForeColor = System.Drawing.Color.Gray;
            this.labelName.Name = "labelActiveSessions";
            this.labelName.Size = new System.Drawing.Size(103, 21);
            this.labelName.TabIndex = 3;
            this.labelName.Text = name;
            this.labelName.Click += SessionPanel_Click;
            this.labelName.MouseEnter += SessionPanel_MouseEnter;
            this.labelName.MouseLeave += SessionPanel_MouseLeave;
            this.labelName.Cursor = Cursors.Hand;

            this.Controls.Add(labelName);
        }

        private void SessionPanel_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = System.Drawing.Color.LightGray;
            this.labelName.ForeColor = System.Drawing.Color.DarkGray;
        }

        private void SessionPanel_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.labelName.ForeColor = System.Drawing.Color.Gray;
        }

        private void SessionPanel_Click(object sender, System.EventArgs e)
        {
            if(IsNew)
                MainClient.StartNewClient(Name, Session);
            else
                MainClient.StartOldCLient(Name, Session);
        }

        public System.Windows.Forms.Label labelName;
    }
}