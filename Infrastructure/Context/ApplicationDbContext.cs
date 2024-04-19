
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<UserEntity>(options)
    {
        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<FeatureEntity> Features { get; set; }

        public DbSet<FeatureContentEntity> FeatureContent { get; set; }
    }
}
