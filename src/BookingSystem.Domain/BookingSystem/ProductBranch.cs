using BookingSystem.BookingSystem.Branches;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem;

public class ProductBranch : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public Guid BranchId { get; set; }

    public virtual Branch? Branch { get; set; }

    public int AvailableBookings { get; set; }

    public int BookingDuration { get; set; }

    public int PreparationTime { get; set; }

    public bool OnlineBooking { get; set; }

    public double ProductPrice { get; set; }

    public Guid? TenantId { get; set; }

    public virtual ICollection<ProductDateSchedule>? ProductDateSchedules { get; set; }

    public virtual ICollection<CustomField>? CustomFields { get; set; }

    public virtual ICollection<Booking>? Bookings { get; set; }


}

