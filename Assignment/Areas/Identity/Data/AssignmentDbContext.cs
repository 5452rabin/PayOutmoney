using Assignment.Areas.Identity.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace Assignment.Data;

public class AssignmentDbContext : IdentityDbContext<AssignmentUser>
{
    public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
        : base(options)
    {
    }
    public DbSet<AssignmentUser> assignmentUsers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
       .Property(t => t.TransferAmountMYR)
        .HasPrecision(18, 4);

        modelBuilder.Entity<Transaction>()
            .Property(t => t.ExchangeRate)
        .HasPrecision(18, 4);

        modelBuilder.Entity<Transaction>()
            .Property(t => t.PayoutAmountNPR)
            .HasPrecision(18, 4);
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }
}
