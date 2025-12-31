
using emes.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace emes
{
    public class EmesDbContext : DbContext
    {
        public EmesDbContext(DbContextOptions<EmesDbContext> options) : base(options) { }

        // DbSet cho entity của bạn
        public DbSet<NGStoreLocationEntity> NGStoreLocations => Set<NGStoreLocationEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NGStoreLocationEntity>(entity =>
            {
                //entity.ToTable("NGStoreLocations"); // tên bảng trong DB
                entity.ToTable("ngstore_locations","ngstore");
                entity.HasKey(e => e.NGstoreLocationID).HasName("ngstore_locations_pkey");
                entity.Property(e => e.NGstoreLocationID).HasColumnName("ngstore_location_id");

                entity.Property(e => e.Name).HasColumnName("name");
               
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
