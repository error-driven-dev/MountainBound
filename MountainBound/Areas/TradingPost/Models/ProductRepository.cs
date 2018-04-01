using System.Linq;
using MountainBound.Models;

namespace MountainBound.Areas.TradingPost.Models
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;


        public void SeedDB()
        {
            if (!_context.Products.Any())
            {
                _context.Products.AddRange(
                    new Product
                    {
                        Name = "Convertible pants",
                        Description = "Lightweight, fast-drying pants that unzip to shorts",
                        Category = "Hiking",
                        Price = 75m,
                        Stock = 5
                    }, new Product
                    {
                        Name = "Longsleeve Shirt",
                        Description = "SPF 40 and bug repellant long sleeve button down linen hiking shirt",
                        Category = "Clothing",
                        Price = 48.95m,
                        Stock = 5
                    }, new Product
                    {
                        Name = "Back Pack",
                        Description = "2.5 L daypack with frame support",
                        Category = "Hiking",
                        Price = 19.50m,
                        Stock = 5
                    }, new Product
                    {
                        Name = "Camel Back Hydration Pro",
                        Description = "2.7 L backpack with build-in hydration pack",
                        Category = "Hiking",
                        Price = 34.95m,
                        Stock = 5
                    }, new Product
                    {
                        Name = "Sleeping Bag",
                        Description = "40 degree light weight sleeping bag",
                        Category = "Camping",
                        Price = 45.00m,
                        Stock = 5
                    }, new Product
                    {
                        Name = "Mini-Propane Stove",
                        Description = "Backpager size mini propane single burner",
                        Category = "Camping",
                        Price = 16,
                        Stock = 5
                    }, new Product
                    {
                        Name = "Headlamp",
                        Description = "3-way long lasting safety headlamp",
                        Category = "Hiking",
                        Price = 29.95m,
                        Stock = 5
                    }, new Product
                    {
                        Name = "2-person tent",
                        Description = "4.3lb 2-person tent with rain fly",
                        Category = "Camping",
                        Price = 75,
                        Stock = 2
                    }, new Product
                    {
                        Name = "Mid-top Hiking boots",
                        Description = "Mountain King boots with extra ankle support, high volume",
                        Category = "Clothing",
                        Price = 120,
                        Stock = 5
                    });
                _context.SaveChanges();
            }
        }
    }
}
