using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbySalto.Junior.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Upišite naziv artikla")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Količina ne može biti negativna")]
        public int Quantity { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Cijena ne može biti negativna")]
        public double Price { get; set; }

        public int OrderId { get; set; }
        
        [ForeignKey("OrderId")]
        [ValidateNever]
        public Order Order { get; set; }
    }
}
