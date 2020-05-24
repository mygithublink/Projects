using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NewLoginlogout.Connections
{
    public static class Connections
    {

        public static OracleConnection conReturn() {
            OracleConnection con = new OracleConnection(ConfigurationManager.AppSettings.Get("OraConnection"));
            return con;
        }
    }
}