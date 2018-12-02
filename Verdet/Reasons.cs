using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class Reasons
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int MainGroupId { get; set; }
        public string MainGroupName { get; set; }
        public string MainGroupDesc { get; set; }

        public static Reasons GetReason(SqlDataReader reader)
        {
            Reasons get = new Reasons()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Desc = reader.GetString(2),
                MainGroupId = reader.GetInt32(3),
                MainGroupName = reader.GetString(4),
                MainGroupDesc = reader.GetString(5),
            };
            return get;
        }
    }
}
