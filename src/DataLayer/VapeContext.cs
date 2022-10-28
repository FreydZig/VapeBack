using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class VapeContext : DbContext
    {
        public VapeContext(DbContextOptions<VapeContext> options) : base(options) 
        { }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Products> Products { get; set; }
    }
}
