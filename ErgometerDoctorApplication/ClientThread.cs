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

        public List<Meting> Metingen { get; }
        public List<ChatMessage> Chat { get; }

        public ClientThread(string name, int session)
        {
            Name = name;
            Session = session;

            window = new SessionWindow(Name, true, Session);
            window.FormClosed += Window_FormClosed;

            Metingen = new List<Meting>();
            Chat = new List<ChatMessage>();
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainClient.RemoveActiveClient(this);
        }

        public void HandleCommand(NetCommand command)
        {
            switch (command.Type)
            {
                case NetCommand.CommandType.DATA:
                    SaveMeting(command.Meting);
                    break;
                case NetCommand.CommandType.CHAT:
                    ChatMessage chat = new ChatMessage(command.DisplayName, command.ChatMessage, false);
                    Chat.Add(chat);
                    window.panelClientChat.Invoke(window.panelClientChat.passChatMessage, new Object[] { chat });
                    break;
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

        public void SaveMeting(Meting m)
        {
            Metingen.Add(m);

            window.heartBeat.updateValue(m.HeartBeat);
            window.RPM.updateValue(m.RPM);
            window.speed.updateValue(m.Speed);
            window.distance.updateValue(m.Distance);
            window.power.updateValue(m.Power);
            window.energy.updateValue(m.Energy);
            window.actualpower.updateValue(m.ActualPower);
        }
    }
}
