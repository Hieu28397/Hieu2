using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.EF;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public List<Order> ListAll()
        {
            return db.Orders.OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<Order> ListOrderApproved()
        {
            return db.Orders.Where(x => x.Status == CommonConstants.ORDER_APPROVED).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<Order> ListOrderNonApproved()
        {
            return db.Orders.Where(x => x.Status == null).OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
