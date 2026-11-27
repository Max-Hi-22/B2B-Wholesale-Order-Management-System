using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentPortalWeb.Controllers;
using AgentPortalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace B2BWholesale.UnitTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        // TEST CASE 1: Kiểm tra chặn đăng nhập khi tài khoản bị khóa (User Lockout Validation)
        [TestMethod]
        public async Task Login_LockedAgentAccount_ShouldReturnViewWithLockoutError()
        {
            // Arrange
            using var context = TestHelper.CreateInMemoryDbContext();
            context.Users.Add(new User
            {
                UserID = 1,
                UserName = "agent_dailoc",
                email = "dailoc@gmail.com",
                password = "Agent@123456",
                @lock = true, // Tài khoản bị khóa
                Role = "Agent"
            });
            await context.SaveChangesAsync();

            var controller = new AccountController(context);
            TestHelper.SetupControllerContext(controller);

            // Act
            var result = await controller.Login("agent_dailoc", "Agent@123456") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(controller.ViewBag.Error);
            Assert.IsTrue(controller.ViewBag.Error.ToString().Contains("lock"));
        }

        // TEST CASE 2: Kiểm tra chặn tài khoản Admin đăng nhập vào Web Portal của Agent
        [TestMethod]
        public async Task Login_AdminRoleOnAgentPortal_ShouldDenyAccess()
        {
            // Arrange
            using var context = TestHelper.CreateInMemoryDbContext();
            context.Users.Add(new User
            {
                UserID = 2,
                UserName = "admin_master",
                email = "admin@b2bwholesale.com",
                password = "Admin@123456",
                @lock = false,
                Role = "Admin" // Sai vai trò cho Web Portal
            });
            await context.SaveChangesAsync();

            var controller = new AccountController(context);
            TestHelper.SetupControllerContext(controller);

            // Act
            var result = await controller.Login("admin_master", "Admin@123456") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(controller.ViewBag.Error);
            Assert.IsTrue(controller.ViewBag.Error.ToString().Contains("Agent"));
        }

        // TEST CASE 3: Kiểm tra logic trừ tồn kho (Stock Deduction) khi đặt hàng hợp lệ
        [TestMethod]
        public async Task PlaceOrder_SufficientStock_ShouldCreateOrderAndDeductStock()
        {
            // Arrange
            using var context = TestHelper.CreateInMemoryDbContext();
            context.Agents.Add(new Agent { AgentID = 1, AgentName = "Minh Anh Trading", Address = "HCMC", Phone = "0901234501" });
            context.Items.Add(new Item { ItemID = 1, ItemName = "Lavie 500ml", Size = "500ml", Price = 4500m, StockQuantity = 500 });
            await context.SaveChangesAsync();

            var controller = new CatalogController(context);
            TestHelper.SetupControllerContext(controller, userId: 3, userName: "agent_minhanh");

            var orderItems = new List<OrderItemInput>
            {
                new OrderItemInput { ItemID = 1, Quantity = 50 }
            };

            // Act
            var result = await controller.PlaceOrder(agentId: 1, items: orderItems) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("MyOrders", result.ActionName);

            var updatedItem = await context.Items.FindAsync(1);
            Assert.AreEqual(450, updatedItem!.StockQuantity, "Tồn kho phải giảm từ 500 xuống 450.");
            Assert.AreEqual(1, await context.Orders.CountAsync());
        }

        // TEST CASE 4: Kiểm tra chặn đặt hàng khi vượt quá số lượng tồn kho (Insufficient Stock Validation)
        [TestMethod]
        public async Task PlaceOrder_InsufficientStock_ShouldBlockOrderAndKeepStockUnchanged()
        {
            // Arrange
            using var context = TestHelper.CreateInMemoryDbContext();
            context.Agents.Add(new Agent { AgentID = 1, AgentName = "Minh Anh Trading", Address = "HCMC", Phone = "0901234501" });
            context.Items.Add(new Item { ItemID = 20, ItemName = "OMO Matic", Size = "3.6kg", Price = 175000m, StockQuantity = 5 });
            await context.SaveChangesAsync();

            var controller = new CatalogController(context);
            TestHelper.SetupControllerContext(controller, userId: 3, userName: "agent_minhanh");

            var orderItems = new List<OrderItemInput>
            {
                new OrderItemInput { ItemID = 20, Quantity = 10 } // Đặt 10 nhưng kho chỉ còn 5
            };

            // Act
            var result = await controller.PlaceOrder(agentId: 1, items: orderItems) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.IsNotNull(controller.TempData["Error"]);

            var itemInDb = await context.Items.FindAsync(20);
            Assert.AreEqual(5, itemInDb!.StockQuantity, "Tồn kho phải giữ nguyên 5 khi đặt quá số lượng.");
            Assert.AreEqual(0, await context.Orders.CountAsync(), "Không được phép tạo đơn hàng khi thiếu tồn kho.");
        }

        // TEST CASE 5: Kiểm tra tính toán chính xác thành tiền từng dòng & tổng tiền đơn hàng (Order Amount Calculation)
        [TestMethod]
        public async Task PlaceOrder_MultipleItems_ShouldCalculateAccurateUnitAmountsAndGrandTotal()
        {
            // Arrange
            using var context = TestHelper.CreateInMemoryDbContext();
            context.Agents.Add(new Agent { AgentID = 2, AgentName = "Hoang Phat Ltd.", Address = "District 1", Phone = "0901234502" });
            context.Items.AddRange(
                new Item { ItemID = 1, ItemName = "Lavie 500ml", Size = "500ml", Price = 4500m, StockQuantity = 100 },
                new Item { ItemID = 5, ItemName = "Coca-Cola", Size = "330ml", Price = 8500m, StockQuantity = 100 }
            );
            await context.SaveChangesAsync();

            var controller = new CatalogController(context);
            TestHelper.SetupControllerContext(controller, userId: 4, userName: "agent_hoangphat");

            var orderItems = new List<OrderItemInput>
            {
                new OrderItemInput { ItemID = 1, Quantity = 20 }, // 20 * 4,500 = 90,000
                new OrderItemInput { ItemID = 5, Quantity = 10 }  // 10 * 8,500 = 85,000 -> Tổng = 175,000
            };

            // Act
            await controller.PlaceOrder(agentId: 2, items: orderItems);

            // Assert
            var details = await context.OrderDetails.ToListAsync();
            Assert.AreEqual(2, details.Count);

            var lavieDetail = details.First(d => d.ItemID == 1);
            var cokeDetail = details.First(d => d.ItemID == 5);
            decimal grandTotal = details.Sum(d => d.UnitAmount);

            Assert.AreEqual(90000m, lavieDetail.UnitAmount);
            Assert.AreEqual(85000m, cokeDetail.UnitAmount);
            Assert.AreEqual(175000m, grandTotal);
        }

        // TEST CASE 6: Kiểm tra từ chối đơn hàng rỗng (tất cả số lượng bằng 0)
        [TestMethod]
        public async Task PlaceOrder_ZeroQuantityForAllItems_ShouldRejectOrder()
        {
            // Arrange
            using var context = TestHelper.CreateInMemoryDbContext();
            context.Agents.Add(new Agent { AgentID = 1, AgentName = "Minh Anh Trading", Address = "HCMC", Phone = "0901234501" });
            context.Items.Add(new Item { ItemID = 1, ItemName = "Lavie 500ml", Size = "500ml", Price = 4500m, StockQuantity = 100 });
            await context.SaveChangesAsync();

            var controller = new CatalogController(context);
            TestHelper.SetupControllerContext(controller, userId: 3, userName: "agent_minhanh");

            var orderItems = new List<OrderItemInput>
            {
                new OrderItemInput { ItemID = 1, Quantity = 0 }
            };

            // Act
            var result = await controller.PlaceOrder(agentId: 1, items: orderItems) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(controller.TempData["Error"]);
            Assert.AreEqual(0, await context.Orders.CountAsync());
        }
    }
}