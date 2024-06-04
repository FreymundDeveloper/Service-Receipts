using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class BackendAPIContext : DbContext
    {
        public BackendAPIContext(DbContextOptions<BackendAPIContext> options) : base(options) { }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Historic> Historicals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Historic)
                .WithOne(h => h.Receipt)
                .HasForeignKey<Historic>(h => h.ReceiptId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
