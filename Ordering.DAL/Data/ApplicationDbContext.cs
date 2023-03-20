using Microsoft.EntityFrameworkCore;
using Ordering.Domain.OrderModel;

namespace Ordering.DAL.Data;

public class ApplicationDbContext: DbContext
{
    // The DbSet property will tell EF Core tha we have a table that needs to be created
    public virtual DbSet<Order> Orders { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
    // On model creating function will provide us with the ability to manage the tables properties
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
