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

        //Services
        builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));  
        builder.Services.AddScoped<AddressRepository>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<AdderessService>();
        builder.Services.AddScoped<UserService>();



        var app = builder.Build();
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
