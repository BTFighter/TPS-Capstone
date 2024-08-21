using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductID { get; set; }

        [Required]
        [ForeignKey("ProductID")]
        public Product? Product { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [Required]
        public double OrderTotal { get; set; }

        /*[Required]
        [Display(Name = "Customer")]
        public int OrderTypeID { get; set; }

        [Required]
        [ForeignKey("OrderTypeID")]
        public OrderType? OrderType { get; set; }*/
    }
}
