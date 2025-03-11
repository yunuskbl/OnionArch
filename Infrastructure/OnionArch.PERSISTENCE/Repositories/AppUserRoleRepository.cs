﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;
using OnionArch.PERSISTENCE.ContextClasses;

namespace OnionArch.PERSISTENCE.Repositories
{
    public class AppUserRoleRepository:BaseRepository<AppUserRole>,IAppUserRoleRepository
    {
        public AppUserRoleRepository(MyContext context):base(context)
        {
            
        }
    }
}
