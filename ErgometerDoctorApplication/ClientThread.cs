using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerDoctorApplication
{
    class ClientThread
    {
        public int Session { get; }
        public string Name { get; }

        public ClientThread(string name, int session)
        {
            Name = name;
            Session = session;
        }

    }
}
