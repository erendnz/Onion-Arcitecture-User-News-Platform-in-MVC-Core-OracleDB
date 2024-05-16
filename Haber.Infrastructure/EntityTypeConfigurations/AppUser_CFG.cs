using Haber.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Infrastructure.EntityTypeConfigurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(2, 1);

            builder.Property(x => x.Ad).HasColumnName("AD");
            builder.Property(x => x.Soyad).HasColumnName("SOYAD");

            var superUser = new AppUser { Id = 1, Ad = "Cevdet", Soyad = "Korkmaz", Email = "cevdet@deneme.com", UserName = "Cevdo", NormalizedEmail="CEVDET@DENEME.COM", NormalizedUserName="CEVDO", SecurityStamp=Guid.NewGuid().ToString(), TwoFactorEnabled=false, ConcurrencyStamp=Guid.NewGuid().ToString() , EmailConfirmed=false};
            
            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            superUser.PasswordHash= hasher.HashPassword(superUser, "Cevdo_123");

            
            builder.HasData(superUser);
        }
    }
}
