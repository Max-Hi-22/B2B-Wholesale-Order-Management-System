using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class ShippingManifestDTO
    {
        // Header Information (Order & Agent)
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string AgentName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // Product Row Information (OrderDetail & Item)
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitAmount { get; set; }
    }
}
