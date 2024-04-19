
using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;
public class FeatureContentRepository(ApplicationDbContext context) : Repo<FeatureContentEntity>(context)

    {

        private readonly ApplicationDbContext _context = context;
    }
