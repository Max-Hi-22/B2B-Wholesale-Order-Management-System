using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class BestSellingItemDTO
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Size { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class AgentRevenueDTO
    {
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public string Phone { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
