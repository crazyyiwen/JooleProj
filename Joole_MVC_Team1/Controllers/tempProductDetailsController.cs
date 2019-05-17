using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositories.Repositories;
using DAL.Models;
using Services;
using Joole_MVC_Team1.Models;

namespace Joole_MVC_Team1.Controllers
{
    public class tempProductDetailsController : Controller
    {
        // GET: tempProductDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);

            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(customer);
            id = 1;
            //tblProduct product = new Service().getProductService((int)id);
            ProductViewModel pvm = new ProductViewModel((int)id);
            return View(pvm);
        }

        public ActionResult ProductCompare2(int? id1, int? id2)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            id1 = 1;
            id2 = 2;
         

            return View(new ProductCmpViewModel((int)id1, (int)id2));

        }
        public ActionResult ProductCompare3(int? id1, int? id2, int? id3)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            if (id3 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id1 = 1;
            id2 = 2;
            id3 = 3;

            return View(new ProductCmpViewModel((int)id1, (int)id2, (int)id3));

        }
    }
}