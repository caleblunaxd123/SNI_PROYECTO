using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace SociedadNacional.DataBase
{
    public class AccesoDB
    {
        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sni"].ConnectionString);
            return con;
        }
    }
}