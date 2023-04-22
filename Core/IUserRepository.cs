using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movie_db_api.Models;

namespace movie_db_api.Core
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByDriverNb(int diverNb);
    }
}