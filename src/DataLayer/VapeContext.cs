using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class VapeContext : DbContext
    {
        public VapeContext(){ }

        public VapeContext(DbContextOptions<VapeContext> options) : base(options) 
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(BaseRepository.GetConnection());
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Products> Products { get; set; }
    }
}
