using System.Linq;
using Project.abznotebook.Web.Models;

namespace Project.abznotebook.Web.Base.Common
{
    public static class FilterLogic
    {
        public static ProductListViewModel FilterByModel(ProductListViewModel productList, FilterViewModel model)
        {
            productList.Products = productList.Products.Where(I => I.Vendor.Contains(model.SelectedVendor));
            productList.PagingInfo.TotalItems = productList.Products.Count();
            return productList;
        }
    }
}