using OEMEVWMS.Repositories.TinVT.ModelExtensions;
using OEMEVWMS.Repositories.TinVT.Models;
using OEMEVWMS.Services.TinVT;

namespace OEMEVWMS.GraphQLWebAPI.TinVT.GraphQL
{
    public class Queries
    {
        private readonly IServiceProviders _serviceProviders;
        public Queries(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders ?? throw new AggregateException(nameof(serviceProviders));
        public async Task<List<PartItemTinVt>> GetAllPartItemsAsync() => await _serviceProviders.PartItemTinVtService.GetAllAsync();
        public async Task<PartItemTinVt?> GetPartTypeByIdAsync(int id) => await _serviceProviders.PartItemTinVtService.GetByIdAsync(id);

        public async Task<PaginationResult<List<PartItemTinVt>>> SearchWithPagingAysnc(PartItemSearchRequest partItemSearch) => await _serviceProviders.PartItemTinVtService.SearchWithPagingAsync(partItemSearch);

    }
}
