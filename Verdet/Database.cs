using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;


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

       

        public static List<User> GetUsers(string[] columns, object[]values, bool isDeleted)
        {
            SqlConnection connect = null;
            List<User> userList = new List<User>();
            try
            {
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
                connect.Open();
                using (SqlCommand cmd = new SqlCommand("GetUsers",connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (columns != null)
                    {
                        for (int i = 0; i < columns.Length; i++)
                        {
                            cmd.Parameters.AddWithValue("@" + columns[i], values[i]);
                        }
                    }
                    if (isDeleted)
                        cmd.Parameters.AddWithValue("@IsDeleted", 1);
                    else
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userList.Add(User.GetUser(reader));
                    }
                }
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
            return userList;
        }


      

        /// <summary>
        /// Kullanıcıyı silmek için IsDeleted 1 gönderilmelidir.
        /// 
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

        public static void AddData(Data data)
        {
            data.ReasonId = (data.ReasonId == null || data.ReasonId.Length == 0) ? "0" : data.ReasonId;
            data.ReasonDesc = (data.ReasonDesc == null || data.ReasonDesc.Length == 0) ? "0" : data.ReasonDesc;
            SqlConnection connect = null;
            try
            {
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
                connect.Open();
                using (SqlCommand cmd = new SqlCommand
                      ("insert into Data(OwnerId, RegDate, Score, ReasonId, ReasonDesc, RecorderId )" +
                      " values (@OwnerId,@RegDate, @Score, @ReasonId, @ReasonDesc, @RecorderId)", connect))
                {
                    cmd.Parameters.AddWithValue("@OwnerId", data.OwnerId);
                    cmd.Parameters.AddWithValue("@RegDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Score", data.Score);
                    cmd.Parameters.AddWithValue("@ReasonId", data.ReasonId);
                    cmd.Parameters.AddWithValue("@ReasonDesc", data.ReasonDesc);
                    cmd.Parameters.AddWithValue("@RecorderId", data.RecorderId);

                    cmd.ExecuteNonQuery();
                }//SqlCommand using end.
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
        }

        public static List<Data> GetData(string[] columns, object[] values, bool isDeleted)
        {
            SqlConnection connect = null;
            List<Data> data = new List<Data>();
            try
            {
                connect = new SqlConnection(Properties.Settings.Default.dbConnString);
                connect.Open();
                using (SqlCommand cmd = new SqlCommand("GetData", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (columns != null)
                    {
                        for (int i = 0; i < columns.Length; i++)
                        {
                            cmd.Parameters.AddWithValue("@" + columns[i], values[i]);
                        }
                    }
                    if (isDeleted)
                        cmd.Parameters.AddWithValue("@IsDeleted", 1);
                    else
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        data.Add(Data.GetData(reader));
                    }
                }
            }//Try end.
            finally
            {
                if (connect != null)
                    connect.Dispose();
            }
            return data;
        }
    }
}
