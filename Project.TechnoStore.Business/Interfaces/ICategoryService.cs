using System.Linq;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        IQueryable<Product> GetAllProducts { get; }
        IQueryable<Category> GetAllCategories { get; }
        IQueryable<Product> GetProductsOfGivenCategory(int CategoryId);
        IQueryable<Product> GetProductsOfGivenCategory(string CategoryName);
    }
}