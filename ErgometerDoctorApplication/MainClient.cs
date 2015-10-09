using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ErgometerDoctorApplication
{
    class MainClient
    {

        public static TcpClient Server { get; }

        public static bool Loggedin;

        private static Thread t;
        private static bool running;

        private static int Session;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;

        static MainClient()
        {
            Server = new TcpClient();

            t = new Thread(run);

            Loggedin = false;
        }

        public static bool Connect(string password)
        {
            if (!Server.Connected)
            {
                Server.Connect(HOST, PORT);

                NetCommand net = NetHelper.ReadNetCommand(Server);
                if (net.Type == NetCommand.CommandType.SESSION)
                    Session = net.Session;
                else
                    throw new Exception("Session not assigned");

                running = true;
                t.Start();
            }

            if (!Loggedin)
            {
                NetCommand command = new NetCommand("Doctor0tVfW", true, password, Session);
                NetHelper.SendNetCommand(Server, command);

                NetCommand response = NetHelper.ReadNetCommand(Server);
                if (response.Type == NetCommand.CommandType.RESPONSE && response.Response == NetCommand.ResponseType.LOGINWRONG)
                {
                    Loggedin = false;
                    return false;
                }

                Loggedin = true;
            }

            return true;
        }

        public static void Disconnect()
        {

            if (Server.Connected)
            {
                NetHelper.SendNetCommand(Server, new NetCommand(NetCommand.CommandType.LOGOUT, Session));
                Loggedin = false;
                Server.Close();
                running = false;
            }
        }

        public static void run()
        {
            while (running)
            {
                if (Server.Connected && Server.Available > 0)
                {
                    NetCommand command = NetHelper.ReadNetCommand(Server);
                    HandToClient(command);
                }
            }
        }

        private static void HandToClient(NetCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
