
using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;
public class FeatureContentRepository(DataContext context) : Repo<FeatureContentEntity>(context)

    {

        private readonly DataContext _context = context;
    }
