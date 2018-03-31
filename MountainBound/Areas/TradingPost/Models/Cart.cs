using System.Collections.Generic;

namespace MountainBound.Areas.TradingPost.Models
{
    public class Cart
    {
        public List<LineItem> LineItems = new List<LineItem>();




    }

    public class LineItem
    {
        public int LineItemId { get; set; }
        public Product Item { get; set; }
        public int? Quantity { get; set; }
  
    }
}
