using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SociedadNacional.Entity;
using SociedadNacional.Services;
using System.Data;
using System.Data.SqlClient;
using SociedadNacional.DataBase;

namespace SociedadNacional.Models
{
    public class UsuarioDAO : ICrudDaoUsuario<Account>
    {
        public void InsertaUsuario(Account u)
        {
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Usuario_Insertar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", u.Name);
            cmd.Parameters.AddWithValue("@password", u.Password);

            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        //public void login(Account acc)
        //{
        //    SqlConnection cn = AccesoDB.getConnection();
        //    SqlCommand com = new SqlCommand();
        //    SqlDataReader dr;
        //    com.CommandText = "select * from Login where username='" + acc.Name + "'and password='" + acc.Password + "'";

        //    try
        //    {
        //        cn.Open();
        //        com.Connection = cn;
        //        dr = com.ExecuteReader();
               
        //       cn.Close();
                 
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}