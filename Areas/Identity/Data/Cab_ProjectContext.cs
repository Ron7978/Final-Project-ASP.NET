using Cab_Project.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using Cab_Project.Models;

namespace Cab_Project.Data;

public class Cab_ProjectContext : IdentityDbContext<Cab_ProjectUser>
{
    public Cab_ProjectContext(DbContextOptions<Cab_ProjectContext> options)
        : base(options)
    {
    }

    public DbSet<Cab_Project.Models.Distance> Distances { get; set; }
    public DbSet<Cab_Project.Models.Driver_Details> Driver_Details { get; set; }
    public DbSet<Cab_Project.Models.Passengers> Passengers { get; set; }
    public DbSet<Cab_Project.Models.Rides_Ordered> Rides_Ordered { get; set; }
    public DbSet<Cab_Project.Models.Rides_Taken> Rides_Taken { get; set; }
    public DbSet<Cab_Project.Models.Selected_Drivers> Selected_Drivers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}
