using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace AbySalto.Junior.Controllers
{
    public class RestaurantController : Controller
    {
        List<SelectListItem> statuses = new List<SelectListItem> {
                new SelectListItem { Value = "Na čekanju", Text = "Na čekanju" },
                new SelectListItem { Value = "U pripremi", Text = "U pripremi" },
                new SelectListItem { Value = "Završena", Text = "Završena" }
            };

        List<SelectListItem> paymentMethods = new List<SelectListItem> {
                new SelectListItem { Value = "Gotovina", Text = "Gotovina" },
                new SelectListItem { Value = "Kartica", Text = "Kartica" }
            };

        List<SelectListItem> currencies = new List<SelectListItem> {
                new SelectListItem { Value = "EUR", Text = "EUR (Euro)" },
                new SelectListItem { Value = "USD", Text = "USD (Američki dolar)" },
                new SelectListItem { Value = "CHF", Text = "CHF (Švicarski franak)" },
                new SelectListItem { Value = "GBP", Text = "GBP (Britanska funta)" },
                new SelectListItem { Value = "CAD", Text = "CAD (Kanadski dolar)" },
                new SelectListItem { Value = "AUD", Text = "AUD (Australski dolar)" }
            };

        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            ViewBag.StatusList = statuses;
            ViewBag.PaymentMethodList = paymentMethods;
            ViewBag.CurrencyList = currencies;

            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if(ModelState.IsValid)
            {
                if (order.Remark == null)
                {
                    order.Remark = "/";
                }

                order.OrderTime = DateTime.Now;

                _context.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusList = statuses;
            ViewBag.PaymentMethodList = paymentMethods;
            ViewBag.CurrencyList = currencies;

            return View();
        }
    }
}
