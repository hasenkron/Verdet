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

        public static void AddUser(User user)
        {
            using (SQLiteConnection connect = new SQLiteConnection())
            {
                connect.ConnectionString = "data source=db/Users.db;Password=basicPassword";
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

    }
}
