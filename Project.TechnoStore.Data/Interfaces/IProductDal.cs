using System.Collections.Generic;
using System.Linq;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IProductDal : IGenericDal<Product>
    {
        public IQueryable<Product> Products { get; }

        Product GetSpesificProduct(int id);
        List<Product> GetProductsByCategoryId(int Id);
    }
}