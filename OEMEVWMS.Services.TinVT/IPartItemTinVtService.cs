using OEMEVWMS.Repositories.TinVT.ModelExtensions;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Services.TinVT
{
    public interface IPartItemTinVtService
    {
        Task<List<PartItemTinVt>> GetAllAsync();
        Task<PartItemTinVt?> GetByIdAsync(int id);

        Task<int> CreateAsync(PartItemTinVt entity);
        Task<int> UpdateAsync(PartItemTinVt entity);
        Task<bool> DeleteAsync(int id);
        Task<List<PartItemTinVt>> SearchAsync(int? id, string? partCode, string? typeName);
        Task<PaginationResult<List<PartItemTinVt>>> SearchWithPagingAsync(PartItemSearchRequest searchRequest);
    }
}
