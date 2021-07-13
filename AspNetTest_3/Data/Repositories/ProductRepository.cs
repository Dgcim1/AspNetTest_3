using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspNetTest_3.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        ApplicationDbContext dbContext; 
        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Create(Product item)
        {
            dbContext.Products.Add(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Product product = GetById(id);
            if (product == null) return false;
            dbContext.Products.Remove(product);//TODO check result
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.Include(c => c.ProductType);
        }

        public Product GetById(int id)
        {
            return dbContext.Products.FirstOrDefault(item => item.id == id);
        }

        public bool Update(Product item)
        {
            dbContext.Products.Update(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }
    }
}
