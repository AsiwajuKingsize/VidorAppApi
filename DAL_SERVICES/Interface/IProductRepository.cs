using DAL_SERVICES.Models;
using DAL_SERVICES.Pagination_Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_SERVICES.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProductsPaged(ProductParameters page);
    }
}
