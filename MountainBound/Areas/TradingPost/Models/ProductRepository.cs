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

 
    }
}
