namespace OEMEVWMS.Services.TinVT
{
    public interface IServiceProviders
    {
        SystemUserAccountService SystemUserAccountService { get; }
        IPartItemTinVtService PartItemTinVtService { get; }
        IPartTypeTinVtService PartTypeTinVtService { get; }
    }
    public class ServiceProviders : IServiceProviders
    {
        private SystemUserAccountService _systemUserAccountService;
        private IPartItemTinVtService _partItemTinVtService;
        private IPartTypeTinVtService _partTypeTinVtService;
        public ServiceProviders()
        {
            
        }
        public SystemUserAccountService SystemUserAccountService
        { 
            get { return _systemUserAccountService ??= new SystemUserAccountService(); }
        }
        public IPartItemTinVtService PartItemTinVtService
        { 
            get { return _partItemTinVtService ??= new PartItemTinVtService(); }
        }
        public IPartTypeTinVtService PartTypeTinVtService
        { 
            get { return _partTypeTinVtService ??= new PartTypeTinVtService(); }
        }

    }
}
