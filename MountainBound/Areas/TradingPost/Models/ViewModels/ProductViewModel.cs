using System.Collections.Generic;

namespace MountainBound.Areas.TradingPost.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int NumPages { get; set; }
    }
}
