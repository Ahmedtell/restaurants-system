namespace Restaurants.Application.Dishes.DTOs
{
    public class DishDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }
        //public static DishDto FromEntity(Dish dish)
        //{
        //    if (dish == null) return null;
        //    return new DishDto
        //    {
        //        ID = dish.ID,
        //        Name = dish.Name,
        //        Description = dish.Description,
        //        Price = dish.Price,
        //        KiloCalories = dish.KiloCalories,
        //    };
        //}
    }
}
