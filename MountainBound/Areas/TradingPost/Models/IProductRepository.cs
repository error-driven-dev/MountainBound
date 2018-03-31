using System.Linq;

namespace MountainBound.Areas.TradingPost.Models
{
    public interface IProductRepository
    {
         IQueryable<Product> Products { get;  }
         
    }
}
