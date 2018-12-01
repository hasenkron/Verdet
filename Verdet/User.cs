using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    class User
    {
        private int id;
        /// <summary>
        /// Id veritabanı tarafından otomatik belirlenir, değişiklik yapılmamalıdır. <para>
        /// Id is automatically determined by the database, no changes should be made. </para>
        /// </summary>
        /// 
        public int Id { get => id;}
        /// <summary>
        /// Sadece veritabanından id değeri çağırılırken kullanılmalıdır. <para>
        /// It should only be used when calling the id value from the database. </para>
        /// </summary>
        public void SetId(int set) => id = set;
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
