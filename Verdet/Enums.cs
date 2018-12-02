using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verdet
{
    public enum OnlineStatus
    {
        Offline = 0,
        Online  = 1
    }

    public enum RoleType
    {
        User     = 0,
        Recorder = 1,
        Manager  = 2,
        Admin    = 3
    }
    
    public enum UserStatus
    {
        Active  = 0,
        Deleted = 1
    }

    public enum GetUsersFrom
    {
        All = 0,
        Username = 1,
        UsernameAndPassword = 3,
        Role = 4,
        OnlineStatus = 5,
        TeamId = 6,
        IsDeleted = 7
    }

}
