using System;

namespace movie_db_api.Models
{
    public class User
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}

