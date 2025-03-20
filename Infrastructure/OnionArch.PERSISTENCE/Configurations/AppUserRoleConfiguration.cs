using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.PERSISTENCE.Configurations
{
    public class AppUserRoleConfiguration:BaseConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            base.Configure(builder);
            builder.HasIndex(p => new { p.UserID, p.RoleID }).IsUnique();

        }
    }
}
