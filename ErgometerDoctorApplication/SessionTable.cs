using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerDoctorApplication
{
    public class SessionTable : DataTable
    {
        public SessionTable() : base()
        {
            this.Columns.Clear();
            this.Columns.Add("User", typeof (string));
            this.Columns.Add("SessionId", typeof (string));
        }
    }
}
