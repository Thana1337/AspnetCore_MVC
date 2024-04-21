
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<UserEntity>(options)
    {
        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<FeatureEntity> Features { get; set; }

        public DbSet<FeatureContentEntity> FeatureContent { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AddressEntity>()
        //        .HasOne(a => a.User)
        //        .WithMany(u => u.Addresses)
        //        .HasForeignKey(a => a.UserId);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}
