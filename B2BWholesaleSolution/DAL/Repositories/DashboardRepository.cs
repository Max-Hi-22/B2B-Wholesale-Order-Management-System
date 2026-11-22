using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DTOs;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DashboardRepository
    {
        private readonly B2BWholesaleDBEntities _context;

        public DashboardRepository()
        {
            _context = new B2BWholesaleDBEntities();
        }

        //1. Alert low inventory
        public List<Item> GetLowStockItems(int threshold)
        {
            return _context.Items
                .Where(i => i.StockQuantity <= threshold)
                .OrderBy(i => i.StockQuantity)
                .ToList();
        }

        //2. Best-selling Product 
        public List<BestSellingItemDTO> GetBestSellingItems(
            DateTime? fromDate = null, DateTime? toDate = null
        )
        {
            var query = _context.OrderDetails
                .Where(od => od.Order.OrderStatus != "Cancelled");

            if (fromDate.HasValue)
            {
                query = query.Where(od => od.Order.OrderDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                DateTime endOfDay = toDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(od => od.Order.OrderDate <= endOfDay);
            }

            return query
                .GroupBy(od => new { od.ItemID, od.Item.ItemName, od.Item.Size })
                .Select(g => new BestSellingItemDTO
                {
                    ItemID = g.Key.ItemID,
                    ItemName = g.Key.ItemName,
                    Size = g.Key.Size,
                    TotalQuantitySold = g.Sum(x => x.Quantity),
                    TotalRevenue = g.Sum(x => x.UnitAmount)
                })
                .OrderByDescending(x => x.TotalQuantitySold)
                .ToList();
        }

        //3. Total revenue by agent
        public List<AgentRevenueDTO> GetRevenueByAgents(int? specificAgentId = null)
        {
            var validOrders = _context.Orders
                .Where(o => o.OrderStatus == "Shipped" || o.OrderStatus == "Delivered");

            if (specificAgentId.HasValue && specificAgentId.Value > 0)
            {
                validOrders = validOrders.Where(o => o.AgentID == specificAgentId.Value);
            }

            return validOrders
                .GroupBy(o => new { o.AgentID, o.Agent.AgentName, o.Agent.Phone })
                .Select(g => new AgentRevenueDTO
                {
                    AgentID = g.Key.AgentID,
                    AgentName = g.Key.AgentName,
                    Phone = g.Key.Phone,
                    TotalOrders = g.Count(),
                    TotalRevenue = g.SelectMany(o => o.OrderDetails)
                        .Sum(od => (decimal?)od.UnitAmount) ?? 0m
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToList();
        }

    }
}
