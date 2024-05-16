using Haber.Domain.Entities;
using Haber.Infrastructure.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Haber.Infrastructure
{
    public class HaberContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public HaberContext()
        {

        }
        public HaberContext(DbContextOptions<HaberContext> options):base(options) 
        {
            
        }

        public DbSet<Favori> Favoriler { get; set; }
        public DbSet<Haber.Domain.Entities.Haber> Haberler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseOracle("User Id = haber; Password = haber; Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SID = orcl)))");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Add Configuration Classes
            builder.ApplyConfiguration(new Haber_CFG());
            builder.ApplyConfiguration(new Kategori_CFG());
            builder.ApplyConfiguration(new Yorum_CFG());
            builder.ApplyConfiguration(new Favori_CFG());
            builder.ApplyConfiguration(new AppUser_CFG());
            builder.ApplyConfiguration(new AppRole_CFG());


            //this.Roles.Add(new AppRole() { Id = 1, Name = "Admin" });
            //this.Roles.Add(new AppRole() { Id = 2, Name = "Uye" });


            ////SuperAdmin, Root
            ////Sistem ilk olustugundaki admin kullanıcısı....

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
            
            //this.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<int> { RoleId = 1, UserId = 1 });


            //this.SaveChanges();

           


        }

    }
}