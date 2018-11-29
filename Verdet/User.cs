using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class User
    {
        private int id;
        private string username;
        private string name;
        private string surname;
        private int role;
        private int teamid;
        private bool onlinestatus;
        private string password;

        public int Id { get => id;}
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Role { get => role; set => role = value; }
        public int TeamId { get => teamid; set => teamid = value; }
        public bool Onlinestatus { get => onlinestatus; set => onlinestatus = value; }
        public string Password { get => password; set => password = value; }
    }
}
