using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetAllProducts();

        Product GetSpesificProduct(int id);
        Product GetSpecificProduct(string SKU);
        List<Product> GetProductsByCategoryId(int Id);
    }
}