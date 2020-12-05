using System.Collections.Generic;
using System.Linq;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        public IQueryable<Product> Products { get; }
        public Product GetSpesificProduct(int id);
        public List<Product> GetProductsByCategoryId(int Id);
    }
}