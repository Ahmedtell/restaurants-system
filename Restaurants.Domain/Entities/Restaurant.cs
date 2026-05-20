
namespace Restaurants.Domain.Entities
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public bool HasDelivery { get; set; }
        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; } = new();

    }
}
