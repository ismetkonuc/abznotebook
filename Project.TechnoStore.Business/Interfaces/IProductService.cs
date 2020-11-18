using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetAllProducts();
        Product GetSpesificProduct(int id);
        Product GetSpecificProduct(string SKU);
        List<Product> GetProductsByCategoryId(int Id);
    }
}