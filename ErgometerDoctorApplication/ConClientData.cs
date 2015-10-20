using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConClientData : Panel
    {
        public System.Windows.Forms.TextBox textBoxPassword;
        public System.Windows.Forms.TextBox textBoxUsername;
        public System.Windows.Forms.Button buttonCreate;
        public System.Windows.Forms.ListBox listUsers;

        public ConClientData() : base()
        {
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.listUsers = new System.Windows.Forms.ListBox();

            // 
            // buttonLogin
            // 
            this.buttonCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(0, -40);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(168, 31);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Aanmaken";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPassword.Location = new System.Drawing.Point(0, 0);
            this.textBoxPassword.MaxLength = 16;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.KeyDown += TextBoxEnterPress;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUsername.Location = new System.Drawing.Point(0, 40);
            this.textBoxUsername.MaxLength = 16;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(167, 20);
            this.textBoxUsername.TabIndex = 2;
            this.textBoxUsername.KeyDown += TextBoxEnterPress;
            //
            // listUsers
            //
            this.listUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listUsers.Location = new System.Drawing.Point(0, 80);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(200, 400);
            this.listUsers.ItemHeight = 25;
            this.listUsers.Items.Add("No Users");
            this.listUsers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPassword);
            // 
            // ConClientData
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConClientData";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;



            this.BackColor = System.Drawing.Color.White;
        }

        private void TextBoxEnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCreate_Click(this, new EventArgs());
            }
        }

        internal void updateUsers(Dictionary<string, string> users)
        {
            this.listUsers.Items.Clear();

            foreach(KeyValuePair<string, string> user  in users)
            {
                this.listUsers.Items.Add(user.Key + ": " + user.Value);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!MainClient.users.ContainsKey(textBoxUsername.Text))
            {
                MainClient.SendNetCommand(new NetCommand(textBoxUsername.Text, textBoxPassword.Text, MainClient.Session));
                MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.USERS, MainClient.Session));

                textBoxUsername.Text = "";

                Thread.Sleep(250);
                updateUsers(MainClient.users);
            }

            
            textBoxPassword.Text = "";
        }
    }
}
