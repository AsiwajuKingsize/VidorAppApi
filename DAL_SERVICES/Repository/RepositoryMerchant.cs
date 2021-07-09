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
    public class RepositoryMerchant : IRepository<Merchant>
    {
        ApplicationDbContext _dbContext;
        public RepositoryMerchant(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Merchant> Create(Merchant _object)
        {
            var obj = await _dbContext.Merchants.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Merchant _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Merchant> GetAll()
        {
            try
            {
                return _dbContext.Merchants.Where(x => x.IsDeleted == false).ToList();
               // return _dbContext.Merchants.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Merchant GetById(int Id)
        {
            return _dbContext.Merchants.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            //return _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Merchant _object)
        {
            _dbContext.Merchants.Update(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Merchant> GetAllModels(QueryStringParameters page)
        {
            return GetAll()
                .OrderBy(c => c.MerchantName)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }
    }
}
