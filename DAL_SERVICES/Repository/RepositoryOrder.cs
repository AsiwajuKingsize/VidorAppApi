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
    public class RepositoryOrder : IRepository<Order>
    {
        ApplicationDbContext _dbContext;
        public RepositoryOrder(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Order> Create(Order _object)
        {
            try
            {
                var obj = await _dbContext.Orders.AddAsync(_object);
                _dbContext.SaveChanges();
                return obj.Entity;
            }
            catch (Exception ee)
            {
                string errorText = ee.Message;
            }
            return null;
        }

        public void Delete(Order _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            try
            {
                return _dbContext.Orders.Where(x => x.IsDeleted == false).ToList();
                // return _dbContext.Merchants.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Order GetById(int Id)
        {
            return _dbContext.Orders.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            //return _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Order _object)
        {
            _dbContext.Orders.Update(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllModels(QueryStringParameters page)
        {
            return GetAll()
                .OrderBy(c => c.Customer)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }
    }
}
