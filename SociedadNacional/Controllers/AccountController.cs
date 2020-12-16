using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SociedadNacional.Entity;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SociedadNacional.Models;

namespace SociedadNacional.Controllers
{
    public class AccountController : Controller
    {
        UsuarioDAO daoUsuario = new UsuarioDAO();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Sni"].ConnectionString);
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult Verify(Account acc)
        {

            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Login where username='" + acc.Name + "'and password='" + acc.Password + "'";
            dr = com.ExecuteReader();

            {
                if (dr.Read())
                {

                    con.Close();
                    return View("PanelControl");
                    
                }
                else
                {
                    con.Close();
                    return View("Error");
                }
            }

        }

       
        public ActionResult PanelControl()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Account acc)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    acc.Name = acc.Name;
                    daoUsuario.InsertaUsuario(acc);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
   
}