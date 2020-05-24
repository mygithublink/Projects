using NewLoginlogout.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewLoginlogout.Connections;
using System.Data;

namespace NewLoginlogout.Controllers
{
   [Authorize]
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        List<Product> p = new List<Product>();
        OracleConnection con = Connections.Connections.conReturn();
        public ActionResult Entry()
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from PRODUCT",con);
                
                cmd.CommandType = CommandType.Text;
                OracleDataReader odr = cmd.ExecuteReader();
                while (odr.Read())
                {
                    Product abc = new Product(Convert.ToInt32(odr.GetValue(0)), odr.GetValue(1).ToString(), odr.GetValue(2).ToString());
                    p.Add(abc);
                }
                return View(p);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();

            }
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from PRODUCT where PRODUCTID=" + id.ToString(), con);
                cmd.CommandType = CommandType.Text;
                OracleDataReader odr = cmd.ExecuteReader();
                Product p;
                if (odr.Read())
                {
                    p = new Product(Convert.ToInt32(odr.GetValue(0)), odr.GetValue(1).ToString(), odr.GetValue(2).ToString());
                }
                else
                    p = null;

                return View("Details", p);
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
            
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product p ,FormCollection fc)
        {
            try
            {
                con.Open();
                //OracleCommand cmd = new OracleCommand("insert into product values(" +"PRODUCTID("+p.PRODUCTID +"),PRODUCTNAME(" + fc["PRODUCTNAME"] + ")," + "PRODUCTCOMPANY(" + fc["PRODUCTCOMPANY"] + "))", con);
                OracleCommand cmd = new OracleCommand("insert into product values("+"S1.NEXTVAL"+" ,'"+fc["PRODUCTNAME"]+"' ,'"+fc["PRODUCTCOMPANY"]+"'"+")", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return RedirectToAction("Entry");
            }
            catch(Exception e)
            {
                throw e;
            }
            finally { con.Close(); }
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from PRODUCT where PRODUCTID=" + id.ToString(), con);
                cmd.CommandType = CommandType.Text;
                OracleDataReader odr = cmd.ExecuteReader();
                Product p;
                if (odr.Read())
                { 
                    p = new Product(Convert.ToInt32(odr.GetValue(0)), odr.GetValue(1).ToString(), odr.GetValue(2).ToString());
                }
                else
                    p = null;

                return View("Edit", p);
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection fc)
        {
            try
            {
                // TODO: Add update logic here
                con.Open();
                OracleCommand cmd = new OracleCommand("update product set PRODUCTNAME=" + "'" + fc["PRODUCTNAME"] + "'" + " where PRODUCTID=" + id.ToString(), con);
                cmd.CommandType = CommandType.Text;
                int noofrow = cmd.ExecuteNonQuery();
                
                return RedirectToAction("Entry");
            }
            catch
            {
                return View();
            }
            finally {
                
                con.Close();
            }
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from PRODUCT where PRODUCTID=" + id.ToString(), con);
                cmd.CommandType = CommandType.Text;
                OracleDataReader odr = cmd.ExecuteReader();
                Product p;
                if (odr.Read())
                {
                    p = new Product(Convert.ToInt32(odr.GetValue(0)), odr.GetValue(1).ToString(), odr.GetValue(2).ToString());
                }
                else
                    p = null;

                return View("Delete", p);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
                try
                {

                    con.Open();
                    OracleCommand cmd = new OracleCommand("delete from product where PRODUCTID=" + id, con);
                    cmd.CommandType = CommandType.Text;
                    int noofrow = cmd.ExecuteNonQuery();

                    return RedirectToAction("Entry");
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {

                    con.Close();
                }

            }

        
    }
}
