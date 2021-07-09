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
    public class RepositoryCategory : IRepository<Category>
    {
        ApplicationDbContext _dbContext;
        public RepositoryCategory(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Category> Create(Category _object)
        {
            var obj = await _dbContext.Categories.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Category _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                //return _dbContext.Categories.Where(x => x.IsDeleted == false).ToList();
                return _dbContext.Categories.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Category GetById(int Id)
        {
            //return _dbContext.Categories.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
            return _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Update(Category _object)
        {
            _dbContext.Categories.Update(_object);
            _dbContext.SaveChanges();
        }


        public IEnumerable<Category> GetAllModels(QueryStringParameters page)
        {
            return GetAll()
                .OrderBy(c => c.CategoryName)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList();
        }
    }

}
