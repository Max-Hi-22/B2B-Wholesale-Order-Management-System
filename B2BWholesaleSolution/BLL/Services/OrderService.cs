using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;

namespace BLL.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo;

        public OrderService()
        {
            _orderRepo = new OrderRepository();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public Order GetOrderWithDetails(int orderId)
        {
            var order = _orderRepo.GetOrderById(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Not found order with ID #{orderId}.");

            return order;
        }

        public decimal CalculateOrderTotal(int orderId)
        {
            var details = _orderRepo.GetOrderDetails(orderId);
            if (details == null || !details.Any())
                return 0m;

            return details.Sum(d => d.UnitAmount);
        }

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            var validStatuses = new[] { "Pending", "Shipped", "Delivered", "Cancelled" };
            if (!validStatuses.Contains(newStatus))
                throw new ArgumentException("Invalid order status.");

            var order = _orderRepo.GetOrderById(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Not found order with ID #{orderId}.");

            string currentStatus = order.OrderStatus;

            if (currentStatus == newStatus)
                return;

            // Quy tắc chuyển trạng thái (State Transition Rules)
            if (currentStatus == "Cancelled")
                throw new InvalidOperationException("Order is already cancelled and cannot have its status changed.");

            if (currentStatus == "Delivered")
                throw new InvalidOperationException("Order is already delivered and cannot have its status changed.");

            if (currentStatus == "Shipped" && newStatus == "Pending")
                throw new InvalidOperationException("Cannot change the status of a shipped order back to pending.");

            _orderRepo.UpdateStatus(orderId, newStatus);
        }

        public List<DAL.DTOs.ShippingManifestDTO> GetShippingManifestData(int orderId)
        {
            var order = _orderRepo.GetOrderById(orderId);
            if (order == null)
                throw new KeyNotFoundException($"Not found #{orderId}.");

            if (string.Equals(order.OrderStatus, "Cancelled",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Cannot export shipping manifest for item.");
            }

            return order.OrderDetails.Select(d => new DAL.DTOs.ShippingManifestDTO
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                AgentName = order.Agent != null ? order.Agent.AgentName : "N/A",
                Address = order.Agent != null ? order.Agent.Address : "N/A",
                Phone = order.Agent != null ? order.Agent.Phone : "N/A",
                ItemID = d.ItemID,
                ItemName = d.Item != null ? d.Item.ItemName : "N/A",
                Size = d.Item != null ? d.Item.Size : "",
                Quantity = d.Quantity,
                UnitPrice = d.Item != null ? d.Item.Price : 0m,
                UnitAmount = d.UnitAmount
            }).ToList();
        }
    }
}
