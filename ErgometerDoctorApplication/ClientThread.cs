using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    class ClientThread
    {
        public int Session { get; }
        public string Name { get; }

        private SessionWindow window;

        public ClientThread(string name, int session)
        {
            Name = name;
            Session = session;

            window = new SessionWindow(Name, true);
            window.FormClosed += Window_FormClosed;
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainClient.RemoveActiveClient(this);
        }

        public void HandleCommand(NetCommand command)
        {
            switch(command.Type)
            {

            }
        }

        public void run()
        {
            Application.Run(window);
        }

        public void stop()
        {
            window.Close();
            MainClient.RemoveActiveClient(this);
        }

        private void sendCommand(NetCommand command)
        {
            MainClient.SendNetCommand(command);
        }

    }
}
