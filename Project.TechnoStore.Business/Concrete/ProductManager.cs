using System.Collections.Generic;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save(Product table)
        {
            _productDal.Save(table);
        }

        public void Delete(Product table)
        {
            _productDal.Delete(table);
        }

        public void Update(Product table)
        {
            _productDal.Update(table);
        }

        public Product GetOrderWithId(int id)
        {
            return _productDal.GetOrderWithId(id);
        }

        public List<Product> GetAllOrders()
        {
            return _productDal.GetAllOrders();
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        public Product GetSpesificProduct(int id)
        {
            return _productDal.GetSpesificProduct(id);
        }


        public Product GetSpecificProduct(string SKU)
        {
            return _productDal.GetSpecificProduct(SKU);
        }

        public List<Product> GetProductsByCategoryId(int Id)
        {
            return _productDal.GetProductsByCategoryId(Id);
        }
    }
}