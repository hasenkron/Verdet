using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class User
    {
        public int Id { get; private set;}
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Role { get; set; }
        public int TeamId { get; set; }
        public int Onlinestatus { get; set; }
        public string Password { get; set; }
        public int IsDeleted { get; set; }

        public static User GetUser(SqlDataReader reader)
        {
            User get = new User
            {
                Id = reader.GetInt32(0),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                Name = reader.GetString(3),
                Surname = reader.GetString(4),
                Role = reader.GetInt32(5),
                Onlinestatus = reader.GetInt32(6),
                TeamId = reader.GetInt32(7),
                IsDeleted = reader.GetInt32(8)
            };
            return get;
        }
    }


}
