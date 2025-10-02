using OEMEVWMS.Repositories.TinVT;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Services.TinVT
{
    public class SystemUserAccountService
    {
        //private readonly SystemUserAccountRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public SystemUserAccountService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            try
            {
                return await _unitOfWork.SystemUserAccountRepository.GetUserAccountAsync(username, password);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
