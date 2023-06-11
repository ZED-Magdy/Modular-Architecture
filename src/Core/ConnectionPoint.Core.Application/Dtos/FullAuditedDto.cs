namespace ConnectionPoint.Core.Application.Dtos;

public class FullAuditedDto<TKey>
{
    public virtual TKey? Id { get; set; }
    public virtual DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public virtual Guid CreatedBy { get; set; } = Guid.Empty;
    public virtual DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
    public virtual Guid ModifiedBy { get; set; } = Guid.Empty;
    public virtual bool Active { get; set; } 
}

public class FullAuditedDto : FullAuditedDto<Guid>
{
}