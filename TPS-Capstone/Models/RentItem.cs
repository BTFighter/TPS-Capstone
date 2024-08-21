using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class RentItem
    {
        [Key]
        public int RentItemID { get; set; }

        [Required]
        [Display(Name = "Rent")]
        public int RentId { get; set; }

        [ForeignKey("RentId")]
        public Rent? Rent { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
