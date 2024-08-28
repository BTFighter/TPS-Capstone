using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS_Capstone.Models
{
    public class Rent
    {
        [Key]
        public int RentID { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        //TODO: Add IDPicture, not sure what DataType to use.

        [MaxLength(255, ErrorMessage = "Your Description exceeds maximum characters")]
        public string Description { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Order Type")]
        public int OrderTypeID  { get; set; }

        [ForeignKey("OrderTypeID")]
        public OrderType OrderType { get; set; }    
    }
}
