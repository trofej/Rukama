using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rukama.Areas.Identity.Data;
using Rukama.Models;

namespace Rukama.Data;

public class AuthDbContext : IdentityDbContext<User>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Rukama.Areas.Identity.Data.User>? User { get; set; }

    public DbSet<Rukama.Models.Object>? Object { get; set; }


    public DbSet<Rukama.Models.Subject>? Subject { get; set; }





}
