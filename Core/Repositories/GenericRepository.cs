using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_db_api.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}