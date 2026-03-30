namespace Scarlet.Comet.Domain.Catalog;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Rating> Ratings { get; set; }

    public Item(int id, string name, decimal price, string description, string imageUrl)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required.", nameof(name));
        }

        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
        }

        Id = id;
        Name = name;
        Price = price;
        Description = description ?? string.Empty;
        ImageUrl = imageUrl ?? string.Empty;
        Ratings = new List<Rating>();
    }

    public void AddRating(Rating rating)
    {
        Ratings.Add(rating);
    }
}