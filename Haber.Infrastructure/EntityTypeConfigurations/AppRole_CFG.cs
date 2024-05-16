using Haber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Infrastructure.EntityTypeConfigurations
{
    public class AppRole_CFG : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(3, 1);

            builder.HasData(new AppRole { Id=1, Name="Admin", NormalizedName="ADMIN", ConcurrencyStamp=Guid.NewGuid().ToString() });
            builder.HasData(new AppRole { Id=2, Name="Uye", NormalizedName="UYE", ConcurrencyStamp=Guid.NewGuid().ToString() });
        }
    }
}
