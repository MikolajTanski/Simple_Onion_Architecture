namespace Simple_Onion_Architecture.Domain.Entities.Common;

public abstract class BaseEntity : BaseEntity<int>
{
}

public abstract class BaseEntity<TIdentity> : IEntity
    where TIdentity : struct, IComparable, IComparable<TIdentity>, IEquatable<TIdentity>, IFormattable
{
    public TIdentity Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}