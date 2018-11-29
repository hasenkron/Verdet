﻿using System;
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
        User  = 0,
        Admin = 1,
    }

    
    public enum GetUsersFrom
    {
        All,
        UsernameAndPassword,
        NameAndSurname,
        Id,
        UserName,
        Name,
        Surname,
        Role,
        TeamId,
        OnlineStatus,
        Password,
        IsDeleted
    }
}