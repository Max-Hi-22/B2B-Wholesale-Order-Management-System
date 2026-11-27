using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentPortalWeb.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required, StringLength(100)]
        public string ItemName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Size { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } 
            = new List<OrderDetail>();
    }
}
