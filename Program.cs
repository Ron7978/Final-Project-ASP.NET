using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cab_Project.Data;
using Cab_Project.Areas.Identity.Data;

namespace Cab_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("Cab_ProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'Cab_ProjectContextConnection' not found.");

                                    builder.Services.AddDbContext<Cab_ProjectContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<Cab_ProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Cab_ProjectContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}