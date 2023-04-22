using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_db_api.Core
{
    public interface IUnitOfWork
    {
        IUserRepository User{get;}
        Task CompleteAsync();
    }
}