using System.ComponentModel.DataAnnotations;

namespace MountainBound.Areas.TradingPost.Models.ViewModels
{
    public class PaymentInfoViewModel
    {
        [Display(Name="Payment Method")]
        [Required(ErrorMessage = "Select a payment method")]
        public PaymentMethods PaymentMethod { get; set; }

        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Credit Card number is not valid.")]
        public string CardNumber { get; set; }

        [Display(GroupName= "Expiration Date")]
        [Required(ErrorMessage = "Required")]
        [Range(1,13, ErrorMessage = "Must be 1-12")]
        public int? Month { get; set; }

        [Required(ErrorMessage = "Required")]
        public int? Year { get; set; }

        [Display(GroupName = "Billing Name and Address")]
        public AddressViewModel BillingAddress { get; set; }
    }


    public enum PaymentMethods
    {
        Discover,
        [Display(Name = "Master Card")]MasterCard,
        Visa,
    }
}
