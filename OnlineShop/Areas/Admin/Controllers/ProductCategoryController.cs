using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var productCategoryDao = new ProductCategoryDao();
            var model = productCategoryDao.ListAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductCategory();
            return View(model);

        }


        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                new ProductCategoryDao().Create(productCategory);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}