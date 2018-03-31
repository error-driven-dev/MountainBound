using System.ComponentModel.DataAnnotations;

namespace MountainBound.Areas.TradingPost.Models.ViewModels
{
    public class AddressViewModel
    {
        [MinLength(2, ErrorMessage = "Must be at least 2 characters.")]
        [MaxLength(55, ErrorMessage = "Must not exceed 55 characters.")]
        [Display(Name= "First Name:")]
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Must be at least 2 characters.")]
        [MaxLength(55, ErrorMessage = "Must not exceed 55 characters.")]
        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Required")]

        [Display(Name = "Phone:")]
        public long? Phone { get; set; }

        
        


        [Required (ErrorMessage = "Required1.")]
        [Display(Name="Address Line 1:")]
        public string AddressLine1 { get; set; }

        [Display(Name="Address Line 2 (Apt, Suite, Floor, Unit):")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Requiredc.")]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Requireds.")]
        [Display(Name = "State:")]
        public string State { get; set; }
        
        [Display(Name = "5-digit Zipcode:")]
        [RegularExpression(@"^\d{5}([\-]?\d{4})?$", ErrorMessage = "Invalid zipcode")]
        [Required(ErrorMessage = "Requiredz.")]
        public int? Zipcode { get; set; }
    }
}
