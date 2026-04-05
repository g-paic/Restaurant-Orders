using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AbySalto.Junior.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Upišite ime kupca")]
        public string Customer { get; set; }

        [Required(ErrorMessage = "Odaberite status")]
        public string Status { get; set; }

        public DateTime OrderTime { get; set; }

        [Required(ErrorMessage = "Odaberite metodu plaćanja")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Upišite adresu dostave")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Upišite kontakt broj")]
        public string ContactNumber { get; set; }

        [ValidateNever]
        public string Remark { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public double TotalPrice { get; set; }

        public double BasePrice { get; set; }

        [Required(ErrorMessage = "Odaberite valutu")]
        public string Currency { get; set; }
    }
}
