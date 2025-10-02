using OEMEVWMS.Repositories.TinVT.Basic;
using OEMEVWMS.Repositories.TinVT.DBContext;
using OEMEVWMS.Repositories.TinVT.Models;

namespace OEMEVWMS.Repositories.TinVT
{
    public class PartTypeTinVtRepository : GenericRepository<PartTypeTinVt>
    {
        public PartTypeTinVtRepository() { }

        public PartTypeTinVtRepository(FA25_PRN232_SE1713_G3_OEMEVWarrantyManagementSystemContext context) => _context = context;

    }
}
