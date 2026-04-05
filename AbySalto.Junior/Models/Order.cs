using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Customer { get; set; }

        public string Status { get; set; }

        public DateTime OrderTime { get; set; }

        public string PaymentMethod { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [ValidateNever]
        public string Remark { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public double TotalPrice { get; set; }

        public string Currency { get; set; }
    }
}
