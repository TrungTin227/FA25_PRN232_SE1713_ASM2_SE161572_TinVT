namespace OEMEVWMS.Repositories.TinVT.ModelExtensions
{
    public class SearchRequest
    {
        public int? currentPage { get; set; }
        public int? pageSize { get; set; }
    }
    public class  PartItemSearchRequest : SearchRequest
    {
        public int? Id { get; set; }
        public string? PartCode { get; set; }
        public string? TypeName { get; set; }
    }
}
