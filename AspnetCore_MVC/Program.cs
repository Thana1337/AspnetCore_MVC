using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore_MVC;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();


        builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));  
       
        //Repositories
        builder.Services.AddScoped<AddressRepository>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<FeatureRepository>();
        builder.Services.AddScoped<FeatureContentRepository>();

        //Services
        builder.Services.AddScoped<AdderessService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<FeatureService>();

        builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", x =>
        {
            x.LoginPath = "/signin";
            x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        });
 



        var app = builder.Build();
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization(); //vad får du göra
        app.UseAuthentication(); //vem är du
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=Index}/{id?}");

        app.Run();
    }
}
