using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        private readonly TechnoStoreDbContext _context;

        public EfCategoryRepository(TechnoStoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetAllProducts => _context.Products;
        public IQueryable<Category> GetAllCategories => _context.Categories;

        public IQueryable<Product> GetProductsOfGivenCategory(string CategoryName) =>
            _context.Products.Where(c => c.Name.Equals(CategoryName)).AsQueryable();

        public IQueryable<Product> GetProductsOfGivenCategory(int CategoryId) =>
            _context.Products.Where(I => I.CategoryId == CategoryId).AsQueryable();

    }
}
