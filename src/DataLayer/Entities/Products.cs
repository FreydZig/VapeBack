using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public int Price { get; set; }

        public int SubtypeId { get; set; }

        public int TypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        public string? Description { get; set; }
    }
}
