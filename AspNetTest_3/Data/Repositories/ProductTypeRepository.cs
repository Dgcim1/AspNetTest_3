using AspNetTest_3.Data.Interfaces;
using AspNetTest_3.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AspNetTest_3.Data.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        ApplicationDbContext dbContext;
        public ProductTypeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Create(ProductType item)
        {
            dbContext.ProductTypes.Add(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            ProductType product = GetById(id);
            if (product == null) return false;
            dbContext.ProductTypes.Remove(product);//TODO check result
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<ProductType> GetAll()
        {
            return dbContext.ProductTypes;
        }

        public ProductType GetById(int id)
        {
            return dbContext.ProductTypes.FirstOrDefault(item => item.id == id);
        }

        public bool Update(ProductType item)
        {
            dbContext.ProductTypes.Update(item);//TODO check result
            dbContext.SaveChanges();
            return true;
        }
    }
}