using Joole_MVC_Team1.Models;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joole_MVC_Team1.Controllers
{
    public class SearchController : Controller
    {
        Service service = new Service();
        // GET: Search
        public ActionResult SearchPage()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Products(SearchViewModel model)
        {
            var products = service.getAllProductsByCriteria(model);
            return PartialView(products);
        }

        public ActionResult Search(int categoryId, int subCategoryId)
        {
            var specFilters = service.ShowSpecFiltersForSubCategory(subCategoryId);
            var typeFilters = service.ShowTypeFiltersForSubCategory(subCategoryId);
            var model = new SearchViewModel(subCategoryId, 0, 0, specFilters, typeFilters);
            return View(model);
        }

        public ActionResult ShowCategories()
        {
            return Json(service.ShowAllCategories(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AutoCompleteSubCategory(SubCategoryViewModel model)
        {
            return Json(service.AutoCompleteSubCategories(model.name, model.category_Id));
        }


    }
}