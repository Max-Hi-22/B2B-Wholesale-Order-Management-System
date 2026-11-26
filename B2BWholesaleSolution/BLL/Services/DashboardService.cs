using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DTOs;
using DAL.Repositories;

namespace BLL.Services
{
    public class DashboardService
    {
        private readonly B2BWholesaleDBEntities _dashboardRepo;

        public DashboardService()
        {
            _dashboardRepo = new B2BWholesaleDBEntities();
        }

        // Alert low inventory (default threshold <= 10)
        public List<Item> GetLowStockItems(int threshold = 10)
        {
            if (threshold < 0)
                throw new ArgumentException("Low stock threshold cannot be negative.", nameof(threshold));

            return _dashboardRepo.Items
                .Where(i => i.StockQuantity <= threshold)
                .OrderBy(i => i.StockQuantity)
                .ToList();
        }

        // Statistics for dashboard
        public List<BestSellingItemDTO> GetBestSellingItems
                (DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = from od in _dashboardRepo.OrderDetails
                        join o in _dashboardRepo.Orders on od.OrderID equals o.OrderID
                        join i in _dashboardRepo.Items on od.ItemID equals i.ItemID
                        where o.OrderStatus != "Cancelled"
                        select new {od, o, i};

            if (fromDate.HasValue)
            {
                DateTime start = fromDate.Value.Date;
                query = query.Where(x => x.o.OrderDate >= start);
            }

            if (toDate.HasValue)
            {
                DateTime end = toDate.Value.Date.AddDays(1).AddTicks(-1); // Include the entire day
                query = query.Where(x => x.o.OrderDate <= end);
            }

            return query
                .GroupBy(x => new { x.i.ItemID, x.i.ItemName, x.i.Size })
                .Select(g => new BestSellingItemDTO
                {
                    ItemID = g.Key.ItemID,
                    ItemName = g.Key.ItemName,
                    Size = g.Key.Size,
                    TotalQuantitySold = g.Sum(x => x.od.Quantity),
                    TotalRevenue = g.Sum(x => x.od.UnitAmount)
                })
                .OrderByDescending(dto => dto.TotalQuantitySold)
                .ToList();
        }

        // Statistics for agents
        public List<AgentRevenueDTO> GetRevenueByAgent(int? specificAgentId = null)
        {
            var validStatuses = new[] { "Shipped", "Delivered" };

            var query = from o in _dashboardRepo.Orders 
                        join a in _dashboardRepo.Agents on o.AgentID equals a.AgentID
                        join od in _dashboardRepo.OrderDetails on o.OrderID equals od.OrderID
                        where validStatuses.Contains(o.OrderStatus)
                        select new { o, a, od };

            if (specificAgentId.HasValue && specificAgentId.Value > 0)
            {
                query = query.Where(x => x.a.AgentID == specificAgentId.Value);
            }

            return query
                .GroupBy(x => new { x.a.AgentID, x.a.AgentName, x.a.Phone })
                .Select(g => new AgentRevenueDTO
                {
                    AgentID = g.Key.AgentID,
                    AgentName = g.Key.AgentName,
                    Phone = g.Key.Phone,
                    TotalOrders = g.Select(x => x.o.OrderID).Distinct().Count(),
                    TotalRevenue = g.Sum(x => x.od.UnitAmount)
                })
                .OrderByDescending(dto => dto.TotalRevenue)
                .ToList();
        }
    }

}
