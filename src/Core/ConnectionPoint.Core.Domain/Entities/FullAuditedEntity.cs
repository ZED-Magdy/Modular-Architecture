namespace ConnectionPoint.Core.Domain.Entities;

public class FullAuditedEntity<TKey>
{
    public virtual TKey? Id { get; set; }
    public virtual DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public virtual Guid CreatedBy { get; set; } = Guid.Empty;
    public virtual DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
    public virtual Guid ModifiedBy { get; set; } = Guid.Empty;
    public virtual DateTime? DeletedOn { get; set; }
    public virtual Guid DeletedBy { get; set; } = Guid.Empty;
    public virtual bool Active { get; set; } 
}

public class FullAuditedEntityDto : FullAuditedEntity<Guid>
{
}