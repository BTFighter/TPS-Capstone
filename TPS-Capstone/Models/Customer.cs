using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Your Phone Number exceeds 11 numbers.")]
        [Display(Name = "Contact Number")]
        [Phone] public string CustomerContact { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }
        
    }
}
