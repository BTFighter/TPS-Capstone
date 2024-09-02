using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;

namespace TPS_Capstone.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string Models { get; set; }

        public string Brand { get; set; }

        public string Specifications { get; set; }

        [MaxLength(12, ErrorMessage = "Your Serial Number exceeds the maximum characters")]
        public int SerialNumber { get; set; }

        public double Price { get; set; }

        public int StockAvailable { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
