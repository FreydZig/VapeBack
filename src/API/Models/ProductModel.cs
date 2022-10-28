using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ProductModel
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public int Price { get; set; }

        public int? SubtypeId { get; set; } = null;

        public int? TypeId { get; set; } = null;

        public string? Description { get; set; }

        [Required]
        public IFormFile MyImage { get; set; }
    }
}
