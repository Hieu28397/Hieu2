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
            order.Status = CommonConstants.ORDER_NON_APPROVED;
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
            return db.Orders.Where(x => x.Status == CommonConstants.ORDER_NON_APPROVED).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public long Edit(Order order)
        {
            order.CreatedDate = DateTime.Now;
            db.SaveChanges();
            return order.ID;
        }

        public bool Update(Order entity)
        {
            try
            {
                var order = db.Orders.Find(entity.ID);
                order.ShipName = entity.ShipName;
                order.ShipMobile = entity.ShipMobile;
                order.ShipAddress = entity.ShipAddress;
                order.ShipEmail = entity.ShipEmail;
                order.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public Order GetByID(long id)
        {
            return db.Orders.Find(id);
        }
    }
}
