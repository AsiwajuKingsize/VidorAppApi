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
    public class RepositoryOrderDetail : IRepository<OrderDetail>
    {
        ApplicationDbContext _dbContext;
        public RepositoryOrderDetail(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<OrderDetail> Create(OrderDetail _object)
        {
            try
            {
                var obj = await _dbContext.OrderDetails.AddAsync(_object);
                _dbContext.SaveChanges();
                return obj.Entity;
            }
            catch (Exception ee)
            {
                string error = ee.Message;
            }

            return null;
        }
        public void Delete(OrderDetail _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            try
            {
                return _dbContext.OrderDetails.ToList();
                // return _dbContext.Merchants.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public OrderDetail GetById(int Id)
        {
            return _dbContext.OrderDetails.Where(x=>x.Id==Id).FirstOrDefault();
            //return _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(OrderDetail _object)
        {
            _dbContext.OrderDetails.Update(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<OrderDetail> GetAllModels(QueryStringParameters page)
        {
            return GetAll()
                .OrderBy(c => c.OrderId)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }
    }
}
