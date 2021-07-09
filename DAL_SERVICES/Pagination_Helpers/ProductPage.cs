using DAL_SERVICES.Interface;
using DAL_SERVICES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_SERVICES.Pagination_Helpers
{
    public class ProductPage : IProductRepository
    {
        private readonly IRepository<Product> _product;
        public ProductPage(IRepository<Product> product)
        {
            _product = product;
        }

        public IEnumerable<Product> GetAllProductsPaged(ProductParameters page)
        {
            return _product.GetAll()
                .OrderBy(c => c.ProductName)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }
       

    }
}
