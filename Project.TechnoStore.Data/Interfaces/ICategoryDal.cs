using System.Linq;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        IQueryable<Product> GetAllProducts { get; }
        IQueryable<Category> GetAllCategories { get; }
        IQueryable<Product> GetProductsOfGivenCategory(int CategoryId);
        IQueryable<Product> GetProductsOfGivenCategory(string CategoryName);

    }
}