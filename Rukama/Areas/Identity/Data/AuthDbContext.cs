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

        builder.Entity<User>()
                    .Property(p => p.Id)
                    .HasColumnName("UserID");

        builder.Entity<User>()
                .HasMany(s => s.Subjects)
                .WithOne(u => u.User)
                .IsRequired()
                .HasForeignKey(i => i.UserID);

        builder.Entity<User>()
                .HasMany(s => s.Objects)
                .WithOne(u => u.User)
                .IsRequired()
                .HasForeignKey(i => i.UserID);

        base.OnModelCreating(builder);


    }
    public DbSet<Rukama.Areas.Identity.Data.User>? User { get; set; }

    public DbSet<Rukama.Models.Object>? Object { get; set; }


    public DbSet<Rukama.Models.Subject>? Subject { get; set; }

    public DbSet<Rukama.Models.Specialization>? Specialization { get; set; }

    public DbSet<Rukama.Models.LegalForm>? LegalForm { get; set; }

    public DbSet<Rukama.Models.ObjectType>? ObjectType { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Rukama.Models.Object> Objects { get; set; }





}
