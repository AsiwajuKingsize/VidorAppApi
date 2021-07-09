//using DAL_SERVICES.Pagination_Helpers;
using DAL_SERVICES.Pagination_Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SERVICES.Interface
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void Delete(T _object);

        IEnumerable<T> GetAllModels(QueryStringParameters page);

    }
}
