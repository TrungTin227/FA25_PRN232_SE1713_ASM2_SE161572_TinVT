using OEMEVWMS.Repositories.TinVT.DBContext;

namespace OEMEVWMS.Repositories.TinVT
{
    public interface IUnitOfWork
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        PartItemTinVtRepository PartItemTinVtRepository { get; }
        PartTypeTinVtRepository PartTypeTinVtRepository { get; }
        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FA25_PRN232_SE1713_G3_OEMEVWarrantyManagementSystemContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private PartItemTinVtRepository _partItemTinVtRepository;
        private PartTypeTinVtRepository _partTypeTinVtRepository;

        public UnitOfWork() => _context ??= new FA25_PRN232_SE1713_G3_OEMEVWarrantyManagementSystemContext();

        public SystemUserAccountRepository SystemUserAccountRepository 
        { 
            get { return _systemUserAccountRepository ??= new(_context); } 
        } 

        public PartItemTinVtRepository PartItemTinVtRepository 
        { 
            get { return _partItemTinVtRepository ??= new(_context); }
        }

        public PartTypeTinVtRepository PartTypeTinVtRepository 
        { 
            get { return _partTypeTinVtRepository ??= new(_context); }
        }
        public int SaveChangesWithTransaction()
        {
            int result = 0;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    result = 0;
                    dbContextTransaction.Rollback();
                    throw;
                }
                return result;
            }
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = 0;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    result = 0;
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
            return result;
        }
    }
}
