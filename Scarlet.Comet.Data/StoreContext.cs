using Microsoft.EntityFrameworkCore;
using Scarlet.Comet.Domain.Catalog;
using Scarlet.Comet.Domain.Orders;

namespace Scarlet.Comet.Data;

public class StoreContext : DbContext
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DbInitializer.Initialize(modelBuilder);
    }
}