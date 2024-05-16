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
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.ToTable("KATEGORILER");
            builder.Property(x => x.KategoriID).UseIdentityColumn(5, 1);

            builder.HasData(
                new Kategori { KategoriID=1, KategoriAdi="Ekonomi" },
                new Kategori { KategoriID = 2, KategoriAdi = "Teknoloji" },
                new Kategori { KategoriID = 3, KategoriAdi = "Spor" },
                new Kategori { KategoriID = 4, KategoriAdi = "Magazin" }
                );
        }
    }
}
