using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace BookingSystem.BookingSystem.Branches;

public class BranchManager : DomainService
{
    private readonly IBranchRepository _branchRepository;

    public BranchManager(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Branch> CreateAsync(
        [NotNull] string branchName,
        [CanBeNull] string branchLocation = null)
    {
        Check.NotNullOrWhiteSpace(branchName, nameof(branchName));

        var existingAuthor = await _branchRepository.FindByNameAsync(branchName);
        if (existingAuthor != null)
        {
            throw new BranchAlreadyExistsException(branchName);
        }

        return new Branch(
            GuidGenerator.Create(),
            branchName,
            branchLocation
        );
    }

    public async Task ChangeNameAsync(
        [NotNull] Branch branch,
        [NotNull] string newName)
    {
        Check.NotNull(branch, nameof(branch));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingAuthor = await _branchRepository.FindByNameAsync(newName);
        if (existingAuthor != null && existingAuthor.Id != branch.Id)
        {
            throw new BranchAlreadyExistsException(newName);
        }

        branch.ChangeName(newName);
    }

}
