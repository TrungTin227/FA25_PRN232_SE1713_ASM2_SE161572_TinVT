using Microsoft.EntityFrameworkCore;
using OEMEVWMS.Repositories.TinVT.Basic;
using OEMEVWMS.Repositories.TinVT.DBContext;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Repositories.TinVT
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }
        public SystemUserAccountRepository(FA25_PRN232_SE1713_G3_OEMEVWarrantyManagementSystemContext context) => _context = context;

        public async Task<SystemUserAccount?> GetUserAccountAsync(string userName, string passsword)
        {
            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => (u.Email == userName || u.UserName == userName) && u.Password == passsword && u.IsActive == true); //Dieu kien account active
        }
    }
}
