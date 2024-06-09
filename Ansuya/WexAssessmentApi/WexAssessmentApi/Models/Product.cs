using System.ComponentModel.DataAnnotations;

namespace WexAssessmentApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage ="Price must be positive")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Stock quantity must be a non-negative number")]
        public int StockQuantity { get; set; }
    }
}
