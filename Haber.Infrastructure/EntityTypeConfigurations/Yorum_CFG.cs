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
    public class Yorum_CFG : IEntityTypeConfiguration<Yorum>
    {
        public void Configure(EntityTypeBuilder<Yorum> builder)
        {
            builder.ToTable("YORUMLAR");
        }
    }
}
