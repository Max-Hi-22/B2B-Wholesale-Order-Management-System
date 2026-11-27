using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentPortalWeb.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public int AgentID { get; set; }

        [Required, StringLength(50)]
        public string OrderStatus { get; set; } = "Pending";

        [ForeignKey("AgentID")]
        public virtual Agent? Agent { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}
