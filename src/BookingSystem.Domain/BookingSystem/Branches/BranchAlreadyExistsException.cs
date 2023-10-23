using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace BookingSystem.BookingSystem.Branches;

public class BranchAlreadyExistsException : BusinessException
{
    public BranchAlreadyExistsException(string branchName)
        : base(BookingSystemDomainErrorCodes.BranchAlreadyExists)
    {
        WithData("branchName", branchName);
    }
}

