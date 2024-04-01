namespace Kemet.ERP.Contracts.Shared
{
    public class PaginationDto : IDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
