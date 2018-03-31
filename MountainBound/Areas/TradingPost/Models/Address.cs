namespace MountainBound.Areas.TradingPost.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }
    }
}
