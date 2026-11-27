using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentPortalWeb.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string email { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string password { get; set; } = string.Empty;

        public bool @lock { get; set; } = false;

        [Required, StringLength(20)]
        public string Role { get; set; } = "Agent";
    }
}
