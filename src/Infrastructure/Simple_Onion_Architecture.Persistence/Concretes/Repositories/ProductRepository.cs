using Simple_Onion_Architecture.Application.Abstractions.Repositories;
using Simple_Onion_Architecture.Domain.Entities;
using Simple_Onion_Architecture.Persistence.Concretes.Repositories.Common;
using Simple_Onion_Architecture.Persistence.Context;

namespace Simple_Onion_Architecture.Persistence.Concretes.Repositories;

public class ProductRepository : Repository<Product, ApplicaitonDbContext>, IProductRepository
{
    public ProductRepository(ApplicaitonDbContext context) : base(context)
    {
    }
}