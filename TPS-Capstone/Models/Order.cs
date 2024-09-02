using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS_Capstone.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers are allowed.")]
        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        //TODO: Add IDPicture, not sure what DataType to use.

        [MaxLength(255, ErrorMessage = "Your Description exceeds maximum characters")]
        public string Description { get; set; }

        [Display(Name = "Order Type")]
        public int OrderTypeID  { get; set; }

        [ForeignKey("OrderTypeID")]
        public OrderType OrderType { get; set; }    
    }
}
