using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS_Capstone.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        [MaxLength(11, ErrorMessage = "Your Phone Number exceeds 11 numbers.")]
        [Display(Name = "Contact Number")]
        public int PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int UserRoleID { get; set; }

        [ForeignKey("UserRoleID")]
        public UserRole? UserRole { get; set; }
    }
}
