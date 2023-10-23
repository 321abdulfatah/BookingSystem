using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem;

public class Product : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public required string ProductName { get; set; }

    public required string BookingMethod { get; set; }

    public int NumberAvailable { get; set; }

    public int ClientAppointments { get; set; }

    public Guid? TenantId { get; set; }

    public virtual ICollection<ProductBranch>? ProductBranches { get; set; }
}

