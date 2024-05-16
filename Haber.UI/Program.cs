using Haber.Application.AutoMapper;
using Haber.Application.Services.AppUserService;
using Haber.Application.Services.HaberService;
using Haber.Application.Services.KategoriService;
using Haber.Application.Services.YorumService;
using Haber.Domain.Entities;
using Haber.Domain.Repositories.Abstract;
using Haber.Infrastructure;
using Haber.Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HaberContext>(x=>x.UseOracle());

builder.Services.AddIdentity<AppUser,AppRole>(x=>x.SignIn.RequireConfirmedAccount=false)
    .AddEntityFrameworkStores<HaberContext>()
    .AddRoles<AppRole>();



//AutoMapper Settings
builder.Services.AddAutoMapper(x => x.AddProfile(typeof(HaberMapper)));


//IoC
builder.Services.AddTransient<IAppUserService, AppUserService>();

builder.Services.AddTransient<IHaberRepository,HaberRepository>();
builder.Services.AddTransient<IHaberService, HaberService>();

builder.Services.AddTransient<IKategoriRepository, KategoriRepository>();
builder.Services.AddTransient<IKategoriService, KategoriService>();

builder.Services.AddTransient<IYorumRepository, YorumRepository>();
builder.Services.AddTransient<IYorumService, YorumService>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
