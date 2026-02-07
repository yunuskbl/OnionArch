using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;
using OnionArch.PERSISTENCE.ContextClasses;

namespace OnionArch.PERSISTENCE.Repositories
{
    public class AppRoleRepository:BaseRepository<AppRole>,IAppRoleRepository
    {
        public AppRoleRepository(MyContext context):base(context)
        {
                
        }

    }
}
