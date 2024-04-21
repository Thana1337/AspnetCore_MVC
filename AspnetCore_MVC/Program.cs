using Infrastructure.Context;
using Infrastructure.Entities;
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

        builder.Services.AddHttpClient();
        builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
        builder.Services.AddDefaultIdentity<UserEntity>(x =>
        {
            x.User.RequireUniqueEmail = true;
            x.SignIn.RequireConfirmedAccount = false;
            x.Password.RequiredLength = 8;

        }).AddEntityFrameworkStores<ApplicationDbContext>();

        //Repositories
        builder.Services.AddScoped<AddressRepository>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<FeatureRepository>();
        builder.Services.AddScoped<FeatureContentRepository>();

        //Services
        builder.Services.AddScoped<AddressService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<FeatureService>();

        builder.Services.AddAuthentication().AddCookie( x =>
        {
            x.LoginPath = "/signin";
            x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        });




        var app = builder.Build();
        app.UseHsts();
        app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        //app.UserSessionValidation();
        app.UseAuthorization(); //vad f�r du g�ra
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
