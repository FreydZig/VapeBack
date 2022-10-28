using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public int? SubtypeId { get; set; } = null;

        public int? TypeId { get; set; } = null;

        [Required]
        [StringLength(100)]
        public string Image { get; set; }

        public string? Description { get; set; } =  null;
    }
}
