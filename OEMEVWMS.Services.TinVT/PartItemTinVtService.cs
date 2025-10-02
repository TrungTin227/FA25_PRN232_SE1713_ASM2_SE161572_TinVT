using OEMEVWMS.Repositories.TinVT;
using OEMEVWMS.Repositories.TinVT.ModelExtensions;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Services.TinVT
{
    public class PartItemTinVtService : IPartItemTinVtService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartItemTinVtService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public async Task<List<PartItemTinVt>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.PartItemTinVtRepository.GetAllAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PartItemTinVt?> GetByIdAsync(int id)
        {

            var allItems = await _unitOfWork.PartItemTinVtRepository.GetAllAsync();
            return allItems.FirstOrDefault(item => item.PartItemTinVtid == id);
        }
        public async Task<int> CreateAsync(PartItemTinVt entity)
        {
            return await _unitOfWork.PartItemTinVtRepository.CreateAsync(entity);
        }
        public async Task<int> UpdateAsync(PartItemTinVt entity)
        {
            return await _unitOfWork.PartItemTinVtRepository.UpdateAsync(entity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            return _unitOfWork.PartItemTinVtRepository.Remove(entity);
        }
        //public async Task<List<PartItemTinVt>> SearchAsync(int id, string partCode, string typeName)
        //{
        //   var allItems = await _partItemRepository.GetAllAsync();
        //      var query = allItems.AsQueryable();
        //    if (id > 0)
        //        {
        //        query = query.Where(item => item.PartItemTinVtid == id);
        //    }
        //    if (!string.IsNullOrEmpty(partCode))
        //    {
        //        query = query.Where(item => item.PartCode != null && item.PartCode.Contains(partCode, StringComparison.OrdinalIgnoreCase));
        //    }
        //    if (!string.IsNullOrEmpty(typeName))
        //    {
        //        query = query.Where(item => item.PartTypeTinVt != null && item.PartTypeTinVt.TypeName != null && item.PartTypeTinVt.TypeName.Contains(typeName, StringComparison.OrdinalIgnoreCase));
        //    }
        //    return query.ToList();
        //}

        public async Task<List<PartItemTinVt>> SearchAsync(int? id, string? partCode, string? typeName)
        {
            return await _unitOfWork.PartItemTinVtRepository.SearchAysnc(id, partCode, typeName);
        }
        public async Task<PaginationResult<List<PartItemTinVt>>> SearchWithPagingAsync(PartItemSearchRequest searchRequest)
        {
            return await _unitOfWork.PartItemTinVtRepository.SearchAsyncWithPaging(searchRequest);
        }

    }
}
