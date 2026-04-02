using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Customer { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        public OrderPaymentMethod PaymentMethod { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        public string Remark { get; set; }
        public List<OrderItem> Items { get; set; }
        public double TotalPrice { get; set; }
        public Currency Currency { get; set; }
    }
}
