
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

        public DbSet<CourseEntity> Courses { get; set; }

        public DbSet<SubscribeEntity> Subscribers { get; set; } 

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
