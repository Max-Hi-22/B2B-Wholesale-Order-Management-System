using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentPortalWeb.Models
{
    [Table("Agent")]
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }

        [Required, StringLength(100)]
        public string AgentName { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string Address { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
