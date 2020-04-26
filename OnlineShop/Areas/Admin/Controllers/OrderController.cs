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


        [HttpGet]
        public ActionResult Edit(long id)
        {
           var list = new SelectList(new List<SelectListItem>
                        {
                            new SelectListItem {Text = "Đơn hàng đã gửi đi", Value = "1"},
                            new SelectListItem {Text = "Đơn hàng chưa được gửi", Value = "0"},
                        }, "Value", "Text");
        ViewBag.myStatus = list;

            var dao = new OrderDao();
            var model = dao.GetByID(id);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var result = dao.Update(model);

            }
            return RedirectToAction("Index", "Order");
        }
    }
}