using BookingSystem.BookingSystem.Branches;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace BookingSystem.EntityFrameworkCore.BookingSystem.Branches;

public class EfCoreBranchRepository
    : EfCoreRepository<BookingSystemDbContext, Branch, Guid>,
        IBranchRepository
{
    public EfCoreBranchRepository(
        IDbContextProvider<BookingSystemDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Branch> FindByNameAsync(string branchName)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(branch => branch.BranchName == branchName);
    }

    public Task<Branch> GetBranchWithSchedulesAsync(Guid branchId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Branch>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                branch => branch.BranchName.Contains(filter)
                )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}