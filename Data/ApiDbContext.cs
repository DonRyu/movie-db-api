using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_db_api.Models;

namespace movie_db_api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            return;
        }
    }
}