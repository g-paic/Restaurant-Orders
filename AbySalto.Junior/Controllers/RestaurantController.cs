using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using AbySalto.Junior.Services;
using AbySalto.Junior.StaticData;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICalculationService _calculationService;

        public RestaurantController(ApplicationDbContext context, ICalculationService calculationService)
        {
            _context = context;
            _calculationService = calculationService;
        }

        public IActionResult Index(bool? sorted)
        {
            List<Order> orders = _context.Orders.ToList();

            if (sorted == true)
            {
                orders = orders.OrderByDescending(order => order.BasePrice).ToList();
            }

            return View(orders);
        }

        public IActionResult SortByTotalPrice()
        {
            return RedirectToAction("Index", new { sorted = true });
        }

        public IActionResult CreateOrUpdateOrder(int? id)
        {
            ViewBag.StatusList = SelectItemData.statuses;
            ViewBag.PaymentMethodList = SelectItemData.paymentMethods;
            ViewBag.CurrencyList = SelectItemData.currencies;

            if (id == null || id == 0)
            {
                return View();
            }
            
            Order order = _context.Orders.Find(id);
            
            if (order == null)
            {
                return View();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult CreateOrUpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.Remark == null)
                {
                    order.Remark = "/";
                }

                order.OrderTime = DateTime.Now;
                
                if (order.Id == 0)
                {
                    _context.Orders.Add(order);
                }
                else
                {
                    _context.Orders.Update(order);
                }

                _context.SaveChanges();

                _calculationService.CalculateOrderTotalPrice(order.Id);
                _calculationService.CalculateBasePrice(order.Id);

                return RedirectToAction("Index");
            }

            ViewBag.StatusList = SelectItemData.statuses;
            ViewBag.PaymentMethodList = SelectItemData.paymentMethods;
            ViewBag.CurrencyList = SelectItemData.currencies;

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }

            Order order = _context.Orders.Find(id);

            if (order == null)
            {
                return RedirectToAction("Index");
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
