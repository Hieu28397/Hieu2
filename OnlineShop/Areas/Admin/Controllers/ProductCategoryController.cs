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

            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name");

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


        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductCategoryDao();
            var productCategory = dao.GetByID(id);

            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name");

            return View(productCategory);
        }

        public void SetViewBag(long? selectedID = null)
        {
            var dao = new ProductCategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDao();
                var result = dao.Update(model);

            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            new ProductCategoryDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}