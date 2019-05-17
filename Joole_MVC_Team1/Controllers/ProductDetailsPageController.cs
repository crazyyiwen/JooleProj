using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joole_MVC_Team1.Controllers
{
    public class ProductDetailsPageController: Controller
    {
        public ActionResult ProductDetails()
        {
            // test service layer
            //GetProductsService test = new GetProductsService();
            //ArrayList singledata;
            //ArrayList doubledata;
            ///*****pass SPropertyID and ProductID*****/
            //singledata = test.ReturnSingleData(4, 4);
            ///*pass DPropertyID and SubCategoryID*/
            //doubledata = test.ReturnDoubleData(6, 1);
            //test.ProductIDToAllPropertyID(2);
            //test.SubCategoryIDToAllPropertyID(1);
            //int testend = 0;
            /*******************************************/
            return View("ProductDetails");
        }
    }
}