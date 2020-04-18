using Model.Dao;
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
    }
}