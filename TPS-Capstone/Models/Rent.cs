using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Rent
    {
        [Key]
        public int RentId { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; }
    }
}
