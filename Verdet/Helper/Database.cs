using System.Collections.Generic;
using System.Data.SQLite;

namespace Verdet.Helper
{
    class Database
    {
        //Create db
        //SQLiteConnection.CreateFile("Users.db");
        //SQLiteConnection baglan = new SQLiteConnection("Data source=Users.db;Version=3;");
        //baglan.SetPassword("basicPassword");
        //baglan.Open();
        

        /// <summary>
        /// Users.db veritabanı dosyasına kullanıcı ekle.
        /// <EN>Add user to Users.db file.</EN>
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            using (SQLiteConnection connect = new SQLiteConnection())
            {
                connect.ConnectionString = string.Format("data source={0}/Users.db;Password=basicPassword",Properties.Settings.Default.dbPath);
                connect.Open();
                using (SQLiteCommand cmd = new SQLiteCommand
                      ("insert into Users(UserName, Name, Surname, Role, TeamId, Password)" +
                      " values ($UserName, $Name, $Surname, $Role, $TeamId, $Password)",connect))
                {
                    cmd.Parameters.AddWithValue("$Username", user.Username);
                    cmd.Parameters.AddWithValue("$Name",user.Name);
                    cmd.Parameters.AddWithValue("$Surname", user.Surname);
                    cmd.Parameters.AddWithValue("$Role", user.Role);
                    cmd.Parameters.AddWithValue("$TeamId", user.TeamId);
                    cmd.Parameters.AddWithValue("$Password", user.Password);

                    cmd.ExecuteNonQuery();
                }//SQLiteCommand using end.
                connect.Close();
            }//SQLiteConnection using end.
        }

        public static List<User> GetUsers(GetUsersFrom type, string[] values)
        {
            string cmdString = "SELECT * FROM Users ";

            switch(type)
            {
                case GetUsersFrom.All:
                    break;
                case GetUsersFrom.UsernameAndPassword:
                    cmdString += "WHERE UserName='"+values[0]+"' AND Password='"+values[1]+"'";
                    break;
                case GetUsersFrom.Id:
                    cmdString += "WHERE Id='{0}'";
                    break;
                
            }

            List<User> userList = new List<User>();
            using (SQLiteConnection connect = new SQLiteConnection())
            {
                connect.ConnectionString = string.Format("data source={0}/Users.db;Password=basicPassword", Properties.Settings.Default.dbPath);
                connect.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(cmdString, connect))
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        User add = new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Name = reader.GetString(2),
                            Surname = reader.GetString(3),
                            Role = reader.GetInt32(4),
                            TeamId = reader.GetInt32(5),
                            Onlinestatus = reader.GetInt32(6),
                            Password = reader.GetString(7),
                            IsDeleted = reader.GetInt32(8)
                        };

                        userList.Add(add);

                    }//While end.
                }//SqliteCommand using end.
                connect.Close();
            }//SqliteConnection using end.
            return userList;
        }

        public static void GetUsers()
        {
            
        }
    }
}
