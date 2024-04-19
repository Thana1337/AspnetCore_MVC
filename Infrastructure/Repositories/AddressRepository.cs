
using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepository(ApplicationDbContext context) : Repo<AddressEntity>(context)
{

    private readonly ApplicationDbContext _context = context;
}


