using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Models;

namespace AbySalto.Junior.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ApplicationDbContext _context;

        public CalculationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CalculateOrderTotalPrice(int orderId)
        {
            Order order = _context.Orders.Find(orderId);

            if (order != null)
            {
                List<OrderItem> items = _context.OrderItems.Where(item => item.OrderId == orderId).ToList();

                if (items == null || !items.Any())
                {
                    order.TotalPrice = 0;
                }
                else
                {
                    double totalPrice = items.Sum(item => item.Quantity * item.Price);
                    order.TotalPrice = Math.Round(totalPrice, 2);
                }

                _context.Orders.Update(order);
                _context.SaveChanges();
            }
        }

        public void CalculateBasePrice(int orderId)
        {
            Order order = _context.Orders.Find(orderId);

            if (order != null)
            {
                switch (order.Currency)
                {
                    case "EUR":
                        order.BasePrice = Math.Round(order.TotalPrice, 2);
                        break;
                    case "USD":
                        order.BasePrice = Math.Round(0.87 * order.TotalPrice, 2);
                        break;
                    case "CHF":
                        order.BasePrice = Math.Round(1.08 * order.TotalPrice, 2);
                        break;
                    case "GBP":
                        order.BasePrice = Math.Round(1.15 * order.TotalPrice, 2);
                        break;
                    case "CAD":
                        order.BasePrice = Math.Round(0.62 * order.TotalPrice, 2);
                        break;
                    case "AUD":
                        order.BasePrice = Math.Round(0.6 * order.TotalPrice, 2);
                        break;
                    default:
                        order.BasePrice = Math.Round(order.TotalPrice, 2);
                        break;
                }

                _context.Orders.Update(order);
                _context.SaveChanges();
            }
        }
    }
}
