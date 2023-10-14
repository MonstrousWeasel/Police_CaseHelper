using Microsoft.AspNetCore.Identity;

namespace Police_CaseHelper.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
