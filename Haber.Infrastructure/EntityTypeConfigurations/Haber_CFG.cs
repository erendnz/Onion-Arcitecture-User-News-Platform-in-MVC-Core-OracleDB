using Haber.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Infrastructure.EntityTypeConfigurations
{
    public class Haber_CFG : IEntityTypeConfiguration<Haber.Domain.Entities.Haber>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Haber> builder)
        {
            builder.ToTable("HABERLER");
        }
    }
}
