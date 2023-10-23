using BookingSystem.BookingSystem.BranchesShared;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem.Branches;

public class Branch : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public string BranchName { get; set; }
    public string BranchLocation { get; set; }
    public Guid? TenantId { get; set; }

    public virtual ICollection<BranchDateSchedule>? BranchDateSchedules { get; set; }
    public virtual ICollection<ProductBranch>? ProductsBranches { get; set; }

    private Branch()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Branch(
        Guid id,
        [NotNull] string branchName,
        [CanBeNull] string? branchLocation = null)
        : base(id)
    {
        SetName(branchName);
        BranchLocation = branchLocation;
    }

    internal Branch ChangeName([NotNull] string branchName)
    {
        SetName(branchName);
        return this;
    }

    private void SetName([NotNull] string branchName)
    {
        BranchName = Check.NotNullOrWhiteSpace(
            branchName,
            nameof(branchName),
            maxLength: BranchConsts.MaxNameLength
        );
    }
}
