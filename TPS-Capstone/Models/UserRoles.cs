using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{ 
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string UserRole { get; set; }
    }
}
