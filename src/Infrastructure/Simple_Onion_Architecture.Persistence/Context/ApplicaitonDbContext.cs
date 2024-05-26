using Microsoft.EntityFrameworkCore;
using Simple_Onion_Architecture.Domain.Entities;
using Simple_Onion_Architecture.Domain.Entities.Common;

namespace Simple_Onion_Architecture.Persistence.Context;

public class ApplicaitonDbContext : DbContext
{
    public ApplicaitonDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<IEntity>();
        foreach (var data in datas)
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                EntityState.Modified => data.Entity.ModifiedDate = DateTime.Now,
                _ => DateTime.Now
            };
        return await base.SaveChangesAsync(cancellationToken);
    }
}