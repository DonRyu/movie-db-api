using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie_db_api.Models
{
    public class UserDto
    {
        public string password { get; set; } = "";
        public string email { get; set; } = "";
    }
}