using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmSdkLibrary
{
    class ConnectionSQL
    {
        private SqlConnection conn;
        public SqlConnection Conn
        {
            get { return conn;}
            set { conn = value; }
        }
    }
}
