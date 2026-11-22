using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository
    {
        private readonly B2BWholesaleDBEntities _context;

        public OrderRepository()
        {
            _context = new B2BWholesaleDBEntities();
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Agent)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders
                .Include(o => o.Agent)
                .Include(o => o.OrderDetails.Select(od => od.Item))
                .FirstOrDefault(o => o.OrderID == orderId);
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _context.OrderDetails
                .Include(od => od.Item)
                .Where(od => od.OrderID == orderId)
                .ToList();
        }

        public void UpdateStatus(int orderId, string newStatus)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                order.OrderStatus = newStatus;
                _context.SaveChanges();
            }
        }
    }
}
