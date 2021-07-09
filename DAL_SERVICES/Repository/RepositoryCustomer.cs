//using DAL_SERVICES.Helpers;
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
    public class RepositoryCustomer : IRepository<Customer>
    {
        ApplicationDbContext _dbContext;
        public RepositoryCustomer(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Customer> Create(Customer _object)
        {
            var obj = await _dbContext.Customers.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Customer _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                return _dbContext.Customers.Where(x => x.IsDeleted == false).ToList();
                // return _dbContext.Merchants.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Customer GetById(int Id)
        {
            return _dbContext.Customers.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            //return _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Customer _object)
        {
            _dbContext.Customers.Update(_object);
            _dbContext.SaveChanges();
        }


        public IEnumerable<Customer> GetAllModels(QueryStringParameters page)
        {
            return GetAll()
                .OrderBy(c => c.CustomerName)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }


    }
}
