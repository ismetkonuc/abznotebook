using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal 
    {
        public List<Product> GetAllProducts()
        {
            using (var context = new TechnoStoreDbContext())
            {
                return context.Products.OrderByDescending(I => I.IsAvailable).ToList();
            }
        }

        public Product GetSpesificProduct(int id)
        {
            using (var context = new TechnoStoreDbContext())
            {
                return context.Products.Single(I => I.Id == id);
            }
        }

        public Product GetSpecificProduct(string SKU)
        {
            using (var context = new TechnoStoreDbContext())
            {
                return context.Products.Single(I => I.SKU == SKU);
            }
        }

        public List<Product> GetProductsByCategoryId(int Id)
        {
            using (var context = new TechnoStoreDbContext())
            {
                return context.Products.Where(I => I.CategoryId == Id).ToList();
            }
        }
    }
}