using Simple_Onion_Architecture.Domain.Entities.Common;

namespace Simple_Onion_Architecture.Application.Abstractions.Repositories.Common;

public interface IRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>
    where TEntity : class, IEntity, new()
{
    IQueryable<TEntity> Query { get; }
}