using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Services.TinVT
{
    public interface IPartTypeTinVtService
    {
        Task<List<PartTypeTinVt>> GetAllAsync();
    }
}
