using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockProject.Models;
using System.Collections;

namespace StockProject.Controllers
{
    public class ProductController : Controller
    {
        private StockDataEntities1 db = new StockDataEntities1();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(db.ProductTables.ToList());
        }


        public ActionResult Stock()
        {
            return View(db.ProductTables.ToList());
        }

        [HttpPost]

        public ActionResult Stock(string pList)
        {

            return null;
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}