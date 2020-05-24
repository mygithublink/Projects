using NewLoginlogout.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace NewLoginlogout.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.AppSettings.Get("OraConnection"));
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from LOGINDETAILS where LOGINID="+"'"+u.loginId.ToString()+"'",con);
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    if (u.passWord.Equals(dr.GetValue(1)))
                    {
                        FormsAuthentication.SetAuthCookie(u.loginId.ToUpper(),false);//
                        return RedirectToAction("Entry", "Product");
                    }
                }


                ModelState.AddModelError("", "INVALID USERNAME OR PASSOWRD!!");
                return View();
            }
            catch (Exception)
            {

                throw;
            }

            finally {
                con.Close();
            }
            
            

            
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public JsonResult KeepSessionAlive()
        {

            return new JsonResult
            {
                Data = "Beat Generated"
            };
        }

        //public OracleConnection OraConnection()
        //{

        //    string oradb = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = Your host name)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE_NAME = XE)));" + "User Id= your user id;Password=<strong>******</strong>;";

        //    return OracleConnection cn ;
        //}


        
    }
}
