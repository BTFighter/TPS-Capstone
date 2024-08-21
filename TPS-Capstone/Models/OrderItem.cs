using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [Required]
        [Display(Name = "Order")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Orders? Orders { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
