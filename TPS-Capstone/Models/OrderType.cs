using System.ComponentModel.DataAnnotations;

namespace TPS_Capstone.Models
{
    public class OrderType
    {
        [Key]
        public int OrderTypeID { get; set; }

        [Required]
        public string OrderTypeName { get; set; }
    }
}
