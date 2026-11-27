using AgentPortalWeb.Data;
using AgentPortalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgentPortalWeb.Controllers
{
    public class OrderItemInput
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }

    public class CatalogController : Controller
    {
        private readonly AppDbContext _context;

        public CatalogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            var agents = await _context.Agents.OrderBy(a => a.AgentName).ToListAsync();
            string currentUserName = HttpContext.Session.GetString("UserName") ?? "";
            string keyword = currentUserName.Replace("agent_", "", StringComparison.Ordinal);

            var matchedAgent = agents.FirstOrDefault(a =>
                a.AgentName.Replace(" ", "").Contains(keyword, StringComparison.OrdinalIgnoreCase));

            ViewBag.Agents = new SelectList(agents, "AgentID", "AgentName", matchedAgent?.AgentID);

            var query = _context.Items.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(i => i.ItemName.Contains(search.Trim()));
            }

            ViewBag.Search = search;
            var items = await query.OrderBy(i => i.ItemName).ToListAsync();
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(int agentId, List<OrderItemInput> items)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            if (agentId <= 0 || !await _context.Agents.AnyAsync(a => a.AgentID == agentId))
            {
                TempData["Error"] = "Please choose a proper agent.";
                return RedirectToAction("Index");
            }

            var selectedItems = items?.Where(x => x.Quantity > 0).ToList();
            if (selectedItems == null || !selectedItems.Any())
            {
                TempData["Error"] = "Please enter more than 1 for at least 1 product.";
                return RedirectToAction("Index");
            }

            // DATABASE TRANSACTION: Kiểm tra tồn kho toàn bộ trước -> Tạo Order + OrderDetails + Trừ StockQuantity
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Kiểm tra tồn kho TẤT CẢ sản phẩm trước khi lưu bất kỳ bản ghi nào
                var validatedItems = new List<(Item DbItem, int Qty)>();
                foreach (var input in selectedItems)
                {
                    var dbItem = await _context.Items.FirstOrDefaultAsync(i => i.ItemID == input.ItemID);
                    if (dbItem == null)
                        throw new InvalidOperationException($"Item ID #{input.ItemID} doesn't exist.");

                    if (dbItem.StockQuantity < input.Quantity)
                    {
                        throw new InvalidOperationException(
                            $"Not enough stock inventory for '{dbItem.ItemName}' " +
                            $"(Order: {input.Quantity}, Inventory: {dbItem.StockQuantity}). " +
                            $"Order cancelled.");
                    }

                    validatedItems.Add((dbItem, input.Quantity));
                }

                // 2. Khi tất cả sản phẩm đều đủ hàng -> Mới tạo Order, OrderDetails và trừ tồn kho
                var newOrder = new Order
                {
                    AgentID = agentId,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Pending"
                };
                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                foreach (var (dbItem, qty) in validatedItems)
                {
                    dbItem.StockQuantity -= qty;

                    _context.OrderDetails.Add(new OrderDetail
                    {
                        OrderID = newOrder.OrderID,
                        ItemID = dbItem.ItemID,
                        Quantity = qty,
                        UnitAmount = qty * dbItem.Price
                    });
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["Success"] = $"Order successfully! New OrderID: #{newOrder.OrderID}.";
                return RedirectToAction("MyOrders", "Orders", new { agentId = agentId });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
