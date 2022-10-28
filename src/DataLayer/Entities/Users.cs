using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
