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

        public static bool loggedin;

        private static Thread t;
        private static bool running;

        public static int Session;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;


        //Server information
        public static List<ClientThread> clients;
        public static Dictionary<string, string> users;
        public static List<int> oldsessions;

        public static void RemoveActiveClient(ClientThread clientThread)
        {
            clients.Remove(clientThread);
        }

        public static Dictionary<int, string> activesessions;

        static MainClient()
        {
            Server = new TcpClient();

            t = new Thread(run);

            loggedin = false;

            clients = new List<ClientThread>();
            users = new Dictionary<string, string>();
            oldsessions = new List<int>();
            activesessions = new Dictionary<int, string>();
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

            if (!loggedin)
            {
                NetCommand command = new NetCommand("Doctor0tVfW", true, password, Session);
                NetHelper.SendNetCommand(Server, command);

                NetCommand response = NetHelper.ReadNetCommand(Server);
                if (response.Type == NetCommand.CommandType.RESPONSE && response.Response == NetCommand.ResponseType.LOGINWRONG)
                {
                    loggedin = false;
                    return false;
                }

                loggedin = true;
            }

            SendNetCommand(new NetCommand(NetCommand.RequestType.SESSIONDATA, Session));

            return true;
        }

        public static void Disconnect()
        {

            if (Server.Connected)
            {
                NetHelper.SendNetCommand(Server, new NetCommand(NetCommand.CommandType.LOGOUT, Session));
                loggedin = false;
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
                    switch(command.Type)
                    {
                        case NetCommand.CommandType.LENGTH:
                            switch(command.Length)
                            {
                                case NetCommand.LengthType.USERS:
                                    users.Clear();
                                    for(int i=0; i<command.LengthValue; i++)
                                    {
                                        NetCommand c = NetHelper.ReadNetCommand(Server);
                                        if(c.Type == NetCommand.CommandType.USER)
                                        {
                                            users.Add(c.DisplayName, c.Password);
                                        }
                                    }
                                    break;
                                case NetCommand.LengthType.SESSIONS:
                                    oldsessions.Clear();
                                    for (int i = 0; i < command.LengthValue; i++)
                                    {
                                        NetCommand c = NetHelper.ReadNetCommand(Server);
                                        if (c.Type == NetCommand.CommandType.SESSION)
                                        {
                                            oldsessions.Add(c.Session);
                                        }
                                    }
                                    break;
                                case NetCommand.LengthType.SESSIONDATA:
                                    activesessions.Clear();
                                    for (int i = 0; i < command.LengthValue; i++)
                                    {
                                        NetCommand c = NetHelper.ReadNetCommand(Server);
                                        if (c.Type == NetCommand.CommandType.SESSIONDATA)
                                        {
                                            activesessions.Add(c.Session, c.DisplayName);
                                        }
                                    }
                                    break;
                                default:
                                    throw new FormatException("Error in NetCommand: Length type is not recognised");
                            }
                            break;
                        default:
                            HandToClient(command);
                            break;
                    }
                    
                }
            }

            Server.Close();
        }

        private static void HandToClient(NetCommand command)
        {
            foreach(ClientThread cl in clients)
            {
                if(cl.Session == command.Session)
                {
                    cl.HandleCommand(command);
                }
            }
        }

        public static void SendNetCommand(NetCommand command)
        {
            NetHelper.SendNetCommand(Server, command);
        }

        private static bool IsSessionRunning(int session)
        {
            foreach(ClientThread cl in clients)
            {
                if (cl.Session == session)
                    return true;
            }

            return false;
        }

        public static void StartNewCLient(string name, int session)
        {
            if (IsSessionRunning(session))
                return;

            //Start new client
            ClientThread cl = new ClientThread(name, session);
            clients.Add(cl);

            //Run client on new thread
            Thread thread = new Thread(new ThreadStart(cl.run));
            thread.Start();
        }
    }
}
