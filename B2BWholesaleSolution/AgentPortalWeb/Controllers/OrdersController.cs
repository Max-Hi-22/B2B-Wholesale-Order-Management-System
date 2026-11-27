using AgentPortalWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgentPortalWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MyOrders(int? agentId)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            var agents = await _context.Agents.OrderBy(a => a.AgentName).ToListAsync();
            ViewBag.Agents = new SelectList(agents, "AgentID", "AgentName", agentId);
            ViewBag.SelectedAgentId = agentId;

            var query = _context.Orders
                .Include(o => o.Agent)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Item)
                .AsQueryable();

            if (agentId.HasValue && agentId.Value > 0)
            {
                query = query.Where(o => o.AgentID == agentId.Value);
            }

            var orders = await query.OrderByDescending(o => o.OrderDate).ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Invoice(int id)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            var order = await _context.Orders
                .Include(o => o.Agent)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Item)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
                return NotFound("Not found the order.");

            return View(order);
        }
    }
}
