using Microsoft.EntityFrameworkCore;
using Scarlet.Comet.Domain.Catalog;

namespace Scarlet.Comet.Data;

public static class DbInitializer
{
    public static void Initialize(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item(
                1,
                "Laptop",
                999.99m,
                "High performance laptop",
                "https://example.com/laptop.jpg"
            ),
            new Item(
                2,
                "Mouse",
                29.99m,
                "Wireless mouse",
                "https://example.com/mouse.jpg"
            )
        );
    }
}