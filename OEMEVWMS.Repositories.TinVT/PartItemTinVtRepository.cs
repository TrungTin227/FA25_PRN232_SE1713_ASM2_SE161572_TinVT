using Microsoft.EntityFrameworkCore;
using OEMEVWMS.Repositories.TinVT.Basic;
using OEMEVWMS.Repositories.TinVT.DBContext;
using OEMEVWMS.Repositories.TinVT.ModelExtensions;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Repositories.TinVT
{
    public class PartItemTinVtRepository : GenericRepository<PartItemTinVt>
    {
        public PartItemTinVtRepository() { }

        public PartItemTinVtRepository(FA25_PRN232_SE1713_G3_OEMEVWarrantyManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<List<PartItemTinVt>> GetAllAsync()
        {
            var items = await _context.PartItemTinVts
                .AsNoTracking()
                .Include(c => c.PartTypeTinVt).ToListAsync();
            return items ?? new List<PartItemTinVt>();
        }

        public async Task<PartItemTinVt> GetByIdAysnc(int id)
        {
            var items = await _context.PartItemTinVts
                .Include(c => c.PartTypeTinVt)
                .FirstOrDefaultAsync();
            return items ?? new PartItemTinVt();
        }

        //public async Task<List<PartItemTinVt>> SearchAysnc(int id, string partCode, string typeName)
        //{
        //    var items = await _context.PartItemTinVts
        //        .Include(c  => c.PartTypeTinVt)
        //        .Where( c => 
        //        (c.PartCode.Contains(partCode) || string.IsNullOrEmpty(partCode))
        //        &&(string.IsNullOrEmpty(typeName) || c.PartTypeTinVt.TypeName.Contains(typeName))
        //        && (c.PartItemTinVtid)
        //        )
        //        .ToListAsync();
        //    return items ?? new List<PartItemTinVt>() ;
        //}
        public async Task<List<PartItemTinVt>> SearchAysnc(int? id, string? partCode, string? typeName)
        {
            IQueryable<PartItemTinVt> query = _context.PartItemTinVts
                .Include(c => c.PartTypeTinVt);

            if (id.HasValue && id.Value > 0)
            {
                query = query.Where(c => c.PartItemTinVtid == id.Value);
            }
            else if (!string.IsNullOrEmpty(partCode))
            {
                query = query.Where(c => c.PartCode.Contains(partCode));
            }
            else if (!string.IsNullOrEmpty(typeName))
            {
                query = query.Where(c => c.PartTypeTinVt.TypeName.Contains(typeName));
            }

            return await query.ToListAsync();
        }

        //public async Task<List<PartItemTinVt>> SearchAysncWithPaging(int id, string partCode, string typeName, int currentPage, int pageSize)
        //{
        //    /*
        //     var totalItems = cashDepositSlips.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        //    cashDepositSlips = cashDepositSlips.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    var result = new PaginationResult<List<TransactionCashDepositSlip>>
        //    {
        //        TotalItems = totalItems,
        //        TotalPages = totalPages,
        //        CurrentPage = currentPage,
        //        PageSize = pageSize,
        //        Items = cashDepositSlips
        //    };
        //     */
        //    var items = await this.SearchAysnc(id, partCode, typeName);

        //    var totalItems = items.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        //    items = items.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    var result = new PaginationResult<List<PartItemTinVt>>
        //    {
        //        TotalItems = totalItems,
        //        TotalPages = totalPages,
        //        CurrentPage = currentPage,
        //        PageSize = pageSize,
        //        Items = items
        //    };
        //    return result ?? new PaginationResult<List<PartItemTinVt>>();
        //}
        public async Task<PaginationResult<List<PartItemTinVt>>> SearchAsyncWithPaging(PartItemSearchRequest request)
        {
            var query = _context.PartItemTinVts
                .AsNoTracking()
                .Include(c => c.PartTypeTinVt)
                .AsQueryable();

            if (request.Id.HasValue && request.Id.Value > 0)
            {
                query = query.Where(c => c.PartItemTinVtid == request.Id.Value);
            }
            if (!string.IsNullOrEmpty(request.PartCode))
            {
                query = query.Where(c => c.PartCode.Contains(request.PartCode));
            }
            if (!string.IsNullOrEmpty(request.TypeName))
            {
                query = query.Where(c => c.PartTypeTinVt.TypeName.Contains(request.TypeName));
            }

            int currentPage = request.currentPage ?? 1;
            int pageSize = request.pageSize ?? 10;

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationResult<List<PartItemTinVt>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = currentPage,
                PageSize = pageSize,
                Items = items
            };
        }


    }
}
