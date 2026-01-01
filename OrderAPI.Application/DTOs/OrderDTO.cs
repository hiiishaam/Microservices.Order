using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Application.DTOs
{
    public class OrderDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0")]
        public decimal TotalPrice { get; set; }
    }
}
