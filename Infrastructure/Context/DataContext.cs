
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public DbSet<AddressEntity> Addresses { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<FeatureEntity> Features { get; set; }

    public DbSet<FeatureContentEntity> FeatureContent { get; set; }




}
