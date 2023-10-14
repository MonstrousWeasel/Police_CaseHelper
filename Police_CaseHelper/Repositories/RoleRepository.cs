using Microsoft.AspNetCore.Identity;
using Police_CaseHelper.Core.Repositories;
using Police_CaseHelper.Data;

namespace Police_CaseHelper.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
