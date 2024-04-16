
using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepository(DataContext context) : Repo<AddressEntity>(context)
{

    private readonly DataContext _context = context;
}
