using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.CONTRACT.Repositories;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.PERSISTENCE.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>

    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Profile).WithOne(x=>x.User).HasForeignKey<AppUserProfile>(x=>x.AppUserId);
            builder.Ignore(x => x.Id);
            builder.HasOne(x => x.Profile).WithOne(x => x.User).HasForeignKey<AppUserProfile>(x => x.Id);
            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.AppUserID);
            builder.HasMany(x => x.Roles).WithOne(x => x.User).HasForeignKey(x => x.UserID).IsRequired();
        }

    }
    
}
