using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Items(int? id)
        {
            List<OrderItem> items = _context.OrderItems.Where(item => item.OrderId == id).ToList();

            // Order order = _context.Orders.Find(id);

            ViewBag.OrderId = id;

            return View(items);
        }

        public IActionResult Create(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index", "Restaurant");
            }

            Order order = _context.Orders.Find(id);

            if (order == null)
            {
                return RedirectToAction("Index", "Restaurant");
            }

            ViewBag.OrderId = id;

            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem item)
        {
            if (ModelState.IsValid)
            {
                Order order = _context.Orders.Find(item.OrderId);
                order.Items.Add(item);
                _context.SaveChanges();

                return RedirectToAction("Items", new { id = item.OrderId });
            }

            ViewBag.OrderId = item.OrderId;

            return View(item);
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index", "Restaurant");
            }

            OrderItem item = _context.OrderItems.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Restaurant");
            }

            ViewBag.OrderItemId = item.OrderItemId;
            ViewBag.OrderId = item.OrderId;

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(OrderItem item)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItems.Update(item);
                _context.SaveChanges();

                return RedirectToAction("Items", new { id = item.OrderId });
            }

            ViewBag.OrderItemId = item.OrderItemId;
            ViewBag.OrderId = item.OrderId;

            return View(item);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index", "Restaurant");
            }

            OrderItem orderItem = _context.OrderItems.Find(id);

            if (orderItem == null)
            {
                return RedirectToAction("Index", "Restaurant");
            }

            int orderId = orderItem.OrderId;

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();

            return RedirectToAction("Items", new { id = orderId });
        }
    }
}
