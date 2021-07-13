using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetTest_3.Data.Repositories
{
    public class ShopCartItemRepository : IRepository<ShopCartItem>
    {
        ApplicationDbContext dbContext;
        public ShopCartItemRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Create(ShopCartItem item)
        {
            dbContext.ShopCartItems.Add(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            ShopCartItem item = GetById(id);
            if (item == null) return false;
            dbContext.ShopCartItems.Remove(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<ShopCartItem> GetAll()
        {
            return dbContext.ShopCartItems.Include(c => c.Product).Include(c => c.User);
        }

        public ShopCartItem GetById(int id)
        {
            return dbContext.ShopCartItems.FirstOrDefault(item => item.id == id);
        }

        public bool Update(ShopCartItem item)
        {
            dbContext.ShopCartItems.Update(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }
    }
}
