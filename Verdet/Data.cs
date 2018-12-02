using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class Data
    {
        public int Id { get; private set; }
        public int OwnerId { get; set; }
        public DateTime RegDate { get; set; }
        public int Score { get; set; }
        public string ReasonId { get; set; }
        public string ReasonDesc { get; set; }
        public int RecorderId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateDesc { get; set; }

        public static Data GetData(SqlDataReader reader)
        {
            Data get = new Data
            {
                Id = reader.GetInt32(0),
                OwnerId = reader.GetInt32(1),
                RegDate = reader.GetDateTime(2),
                Score = reader.GetInt32(3),
                ReasonId = reader.GetString(4),
                ReasonDesc = reader.GetString(5),
                RecorderId = reader.GetInt32(6),
                UpdateDate = reader.GetDateTime(7),
                UpdateDesc = reader.GetString(8)
            };
            return get;
        }
    }
}
