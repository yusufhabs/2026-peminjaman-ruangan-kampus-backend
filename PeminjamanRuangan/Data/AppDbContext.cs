using Microsoft.EntityFrameworkCore;
using PeminjamanRuangan.Models;

namespace PeminjamanRuangan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Peminjaman> Peminjamans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peminjaman>()
                .HasQueryFilter(p => p.DeletedAt == null);
        }
    }
}