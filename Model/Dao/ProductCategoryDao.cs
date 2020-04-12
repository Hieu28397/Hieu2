using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.EF;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public long Create(ProductCategory producCategory)
        {
            if (string.IsNullOrEmpty(producCategory.MetaTitle))
            {
                producCategory.MetaTitle = StringHelper.ToUnsignString(producCategory.Name);
            }

            producCategory.CreatedDate = DateTime.Now;
            db.ProductCategories.Add(producCategory);
            db.SaveChanges();
            return producCategory.ID;
        }
    }
}
