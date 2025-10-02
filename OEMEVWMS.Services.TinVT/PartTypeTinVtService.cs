using OEMEVWMS.Repositories.TinVT;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Services.TinVT
{
    public class PartTypeTinVtService : IPartTypeTinVtService
    {

        private readonly IUnitOfWork _unitOfWork;
        public PartTypeTinVtService() => _unitOfWork = new UnitOfWork();

        public async Task<List<PartTypeTinVt>> GetAllAsync()
        {
            try
            {
                var partTypes = await _unitOfWork.PartTypeTinVtRepository.GetAllAsync();
                return partTypes;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
