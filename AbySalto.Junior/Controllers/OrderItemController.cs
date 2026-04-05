using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using AbySalto.Junior.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICalculationService _calculationService;

        public OrderItemController(ApplicationDbContext context, ICalculationService calculationService)
        {
            _context = context;
            _calculationService = calculationService;
        }
        
        public IActionResult Items(int? id)
        {
            List<OrderItem> items = _context.OrderItems.Where(item => item.OrderId == id).ToList();
            Order order = _context.Orders.Find(id);

            ViewBag.OrderId = id;
            ViewBag.Currency = order.Currency;

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
                double price = Math.Round(item.Price, 2);
                item.Price = price;

                Order order = _context.Orders.Find(item.OrderId);

                order.Items.Add(item);
                _context.SaveChanges();

                _calculationService.CalculateOrderTotalPrice(item.OrderId);
                _calculationService.CalculateBasePrice(item.OrderId);

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
                double price = Math.Round(item.Price, 2);
                item.Price = price;

                _context.OrderItems.Update(item);
                _context.SaveChanges();

                _calculationService.CalculateOrderTotalPrice(item.OrderId);
                _calculationService.CalculateBasePrice(item.OrderId);

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

            _calculationService.CalculateOrderTotalPrice(orderId);
            _calculationService.CalculateBasePrice(orderId);

            return RedirectToAction("Items", new { id = orderId });
        }
    }
}
