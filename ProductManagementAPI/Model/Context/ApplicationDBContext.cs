using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Model.Entities;

namespace ProductManagementAPI.Model.Context;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<AppLog> AppLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product {Id = 1001, Name = "iPhone", Description = "The Best Phone in the World", Brand = "Apple", Price = 79000, Quantity = 100},
            new Product {Id = 1002,  Name = "MacBook Air", Description = "The Best Laptop in the World", Brand = "Apple", Price = 119000, Quantity = 100},
            new Product {Id = 1003,  Name = "iPad", Description = "The Best Tablet in the World", Brand = "Apple", Price = 59000, Quantity = 100},
            new Product {Id = 1004,  Name = "iMac", Description = "The Best PC in the World", Brand = "Apple", Price = 149000, Quantity = 100},
            new Product {Id = 1005,  Name = "iWatch", Description = "The Best Smart Watch in the World", Brand = "Apple", Price = 39000, Quantity = 100}
        );
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt =
                    DateTime.UtcNow;
                entry.Entity.ModifiedAt =
                    DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedAt =
                    DateTime.UtcNow;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}