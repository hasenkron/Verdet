using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Role { get; set; }
        public int TeamId { get; set; }
        public int Onlinestatus { get; set; }
        public string Password { get; set; }
        public int IsDeleted { get; set; }

    }

}
