using System.ComponentModel.DataAnnotations;

namespace TPS_Capstone.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
