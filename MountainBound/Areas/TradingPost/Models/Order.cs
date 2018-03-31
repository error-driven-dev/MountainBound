using System.Collections.Generic;

namespace MountainBound.Areas.TradingPost.Models
{

    public class Order
    {
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public Address ShippingInfo { get; set; }
        
        public List<LineItem> OrderItems { get; set; } = new List<LineItem>();
    }
}
