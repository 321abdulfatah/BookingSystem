using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.BookingSystem.Branches;

public interface IBranchRepository : IRepository<Branch, Guid>
{
    Task<Branch> FindByNameAsync(string name);

    Task<List<Branch>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string? filter = null
    );

    Task<Branch> GetBranchWithSchedulesAsync(Guid branchId);

}