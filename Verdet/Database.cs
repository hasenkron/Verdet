using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Verdet
{
    class Database
    {

        /// <summary>
        /// Users tablosuna kullanıcı ekle.
        /// Add user to Users table.
        /// </summary>
        /// <param name="user">Eklenecek kullanıcı. / User to be added. </param>
        /// 
        public static void AddUser(User user)
        {
            SqlConnection connect = null;
            try
            {
                connect = new SqlConnection
                {
                    ConnectionString = string.Format(Properties.Settings.Default.dbConnString, Properties.Settings.Default.dbPath)
                };
                connect.Open();
                using (SqlCommand cmd = new SqlCommand
                      ("insert into Users(Username, Password, Name, Surname, Role, TeamId)" +
                      " values (@Username,@Password, @Name, @Surname, @Role, @TeamId)", connect))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Name",user.Name);
                    cmd.Parameters.AddWithValue("@Surname", user.Surname);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@TeamId", user.TeamId);
                    

                    cmd.ExecuteNonQuery();
                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
        }


        /// <summary>
        /// Tüm kullanıcıları çağırmak için sütun ve değer null olmalıdır. Birden fazla sütun AND operatörü ile birleştirilir.
        /// Sütun adları Database.GetColumns ile çekilebilir. 
        /// 
        /// <para>
        /// The column and value must be NULL to call all users.
        /// Multiple columns are combined with the AND operator.
        /// Column names can be taken with Database.GetColumns. 
        /// </para></summary>
        /// 
        /// <param name="colunms">
        /// Sütun veya sütunlar
        /// Column or columns
        /// </param>
        /// 
        /// <param name="values">
        /// Aranacak değer veya  değerler.
        /// Value/values to be search
        /// </param>
        /// 
        /// <returns>
        /// Liste boş dönüyorsa değer bulunamamış demektir.
        /// If the list returns empty, the value is not found.
        /// </returns>
        public static List<User> GetUsers(string[] colunms, string[] values)
        {
            List<User> userList = new List<User>();
            string cmdString = "SELECT * FROM Users WHERE ";

            #region cmdString manipulate.
            if (colunms == null || colunms.Length==0)
                cmdString = cmdString.Remove(20);
            else
            {
                for (int i = 0; i < colunms.Length; i++)
                {
                    if (colunms.Length == 1)
                        cmdString += string.Format("{0}='{1}'", colunms[i], values[i]);
                    else
                        cmdString += string.Format("{0}='{1}' AND ", colunms[i], values[i]);
                }
                if (colunms.Length > 1)
                    cmdString = cmdString.Remove(cmdString.Length - 4, 4);
            }
            #endregion

            SqlConnection connect = null;
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = string.Format(Properties.Settings.Default.dbConnString, Properties.Settings.Default.dbPath);
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(cmdString, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    while(reader.Read())
                    {
                        User add = new User
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

                        userList.Add(add);

                    }//While end.
                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
            return userList;
        }

        public static void UpdateUser(User update)
        {
            SqlConnection connect = null;
            try
            {
                connect = new SqlConnection
                {
                    ConnectionString = string.Format(Properties.Settings.Default.dbConnString, Properties.Settings.Default.dbPath)
                };
                connect.Open();
                using (SqlCommand cmd = new SqlCommand
                      ("UPDATE Users SET Username=@Username, Password=@Password, Name=@Name, Surname=@Surname, Role=@Role," +
                      "OnlineStatus=@OnlineStatus, TeamId=@TeamId, IsDeleted=@IsDeleted WHERE Id=@Id",connect))
                {
                    cmd.Parameters.AddWithValue("@Id", update.Id);
                    cmd.Parameters.AddWithValue("@Username", update.Username);
                    cmd.Parameters.AddWithValue("@Password", update.Password);
                    cmd.Parameters.AddWithValue("@Name", update.Name);
                    cmd.Parameters.AddWithValue("@Surname", update.Surname);
                    cmd.Parameters.AddWithValue("@Role", update.Role);
                    cmd.Parameters.AddWithValue("@OnlineStatus", update.Onlinestatus);
                    cmd.Parameters.AddWithValue("@TeamId", update.TeamId);
                    cmd.Parameters.AddWithValue("@IsDeleted", update.IsDeleted);

                    cmd.ExecuteNonQuery();
                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
        }
        /// <summary>
        /// Sütun isimlerini getirir.
        /// </summary>
        /// <param name="tableName">Tablo adı</param>
        /// <returns></returns>
        public static string[] GetColumns(string tableName)
        {
            string[] columns;
            SqlConnection connect = null;
            string cmdString = string.Format("SELECT * FROM {0} ", tableName);
            try
            {
                connect = new SqlConnection
                {
                    ConnectionString = string.Format(Properties.Settings.Default.dbConnString, Properties.Settings.Default.dbPath)
                };
                connect.Open();

                using (SqlCommand cmd = new SqlCommand(cmdString, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToArray();

                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
            return columns;
        }
    }
}
