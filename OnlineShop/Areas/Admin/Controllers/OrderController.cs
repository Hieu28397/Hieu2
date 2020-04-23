using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
    
        public ActionResult Index()
        {
            var model = new OrderDao().ListAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
                new OrderDao().Create(model);
                return RedirectToAction("Index");
            }

            SetViewBag();
            return View();
        }

        public ActionResult OrderApproved()
        {
            var model = new OrderDao().ListOrderApproved();
            return View(model);
        }

        public ActionResult OrderNonApproved()
        {
            var model = new OrderDao().ListOrderNonApproved();
            return View(model);
        }

        public void SetViewBag(long? selectedID = null)
        {
            var dao = new OrderDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}