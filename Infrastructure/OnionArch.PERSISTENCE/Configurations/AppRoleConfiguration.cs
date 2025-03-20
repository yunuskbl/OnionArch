using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.PERSISTENCE.Configurations
{
    public class AppRoleConfiguration : BaseConfiguration<AppRole>
    {

        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.Id);
            builder.HasMany(x => x.UserRole).WithOne(x => x.Role).HasForeignKey(x => x.RoleID).IsRequired();
        }
    }
}
