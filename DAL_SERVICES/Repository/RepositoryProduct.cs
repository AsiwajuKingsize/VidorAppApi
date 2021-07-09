using DAL_SERVICES.Interface;
using DAL_SERVICES.Models;
using DAL_SERVICES.Pagination_Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL_SERVICES.Data.ApplicationDBContext;

namespace DAL_SERVICES.Repository
{
    public class RepositoryProduct : IRepository<Product>
    {
        ApplicationDbContext _dbContext;
        public RepositoryProduct(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Product> Create(Product _object)
        {
            var obj = await _dbContext.Products.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Product _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _dbContext.Products.Where(x => x.IsDeleted == false).ToList();
                // return _dbContext.Merchants.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Product GetById(int Id)
        {
            return _dbContext.Products.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            //return _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Product _object)
        {
            _dbContext.Products.Update(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllModels(QueryStringParameters page)
        {
            return GetAll()
                .OrderBy(c => c.ProductName)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }
    }
}
