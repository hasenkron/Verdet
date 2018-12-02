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
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
                connect.Open();
                using (SqlCommand cmd = new SqlCommand
                      ("insert into Users(Username, Password, Name, Surname, Role, TeamId, RegDate)" +
                      " values (@Username,@Password, @Name, @Surname, @Role, @TeamId, @RegDate)", connect))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Name",user.Name);
                    cmd.Parameters.AddWithValue("@Surname", user.Surname);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@TeamId", user.TeamId);
                    cmd.Parameters.AddWithValue("@RegDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
        }



        public static List<User> GetUsers()
        {
            string cmdString = null;

            //string cmdString = BuildCmdString("Users", colunms, values, operators);
            SqlConnection connect = null;
            List<User> userList = new List<User>();
            try
            {
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
                connect.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User add = User.GetUser(reader);
                        userList.Add(add);
                    }
                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
            return userList;
        }

        public static List<User> GetUsers(GetUsersFrom type)
        {

            return null;
        }

        

        private static string BuildCmdString(string tableName, string[] colunms, string[] values, string[] operators)
        {
            

            string[] opfix = new string[operators.Length + 1];
            Array.Copy(operators, opfix, operators.Length);
            string cmdString = string.Format("SELECT * FROM {0} WHERE ", tableName);
            if (colunms == null || colunms.Length == 0 || values == null || values.Length == 0)
                cmdString = cmdString.Remove(20);
            else
            {
                for (int i = 0; i < colunms.Length; i++)
                {
                    if (colunms.Length == 1)
                        cmdString += string.Format("{0}='{1}'", colunms[i], values[i]);
                    else
                        cmdString += string.Format("{0}='{1}' {2} ", colunms[i], values[i],opfix[i]);
                }
                //if (colunms.Length > 1)
                //    cmdString = cmdString.Remove(cmdString.Length - 4, 4);
            }
            
            return cmdString;
        }

        /// <summary>
        /// Id değeri değiştirilmemelidir.
        /// Kullanıcıyı silmek için IsDeleted 1 gönderilmelidir.
        /// 
        /// Id value should not be changed.
        /// IsDeleted 1 must be sent to delete the user.
        /// </summary>
        /// <param name="update"></param>
        public static void UpdateUser(User update)
        {
            SqlConnection connect = null;
            try
            {
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
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
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
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

        public static List<Data> GetData()
        {
            return null;
        }
    }
}
