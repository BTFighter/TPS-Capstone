using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS_Capstone.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [Display(Name = "Rent ID No.")]
        public int RentID { get; set; }

        [ForeignKey("RentID")]
        public Order Rent { get; set; }

        [Display(Name = "Product ID No.")]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public int Quantity { get; set; }


    }
}
