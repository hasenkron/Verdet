using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class asdHelper
    {
        public static void AddUser()
        {
            User add = new User();
            add.Username = "kullanıcı adı";
            add.Name = "ad";
            add.Surname = "soyad";
            add.Role = 0;
            add.TeamId = 1;
            add.Password = "yoyemadafaka";
        }
    }
}
