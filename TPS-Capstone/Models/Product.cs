using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double ProductPrice { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public Category? CategoryName { get; set; }

        [Required]
        [Display(Name = "Availability")]
        public bool isRentable { get; set; }
    }
}
