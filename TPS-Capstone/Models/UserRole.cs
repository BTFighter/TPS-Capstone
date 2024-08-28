using System.ComponentModel.DataAnnotations;

namespace TPS_Capstone.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }

        public string UserRoleName { get; set; }

    }
}
