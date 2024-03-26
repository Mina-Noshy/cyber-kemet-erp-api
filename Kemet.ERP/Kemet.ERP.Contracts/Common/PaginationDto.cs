namespace Kemet.ERP.Contracts.Common
{
    public class PaginationDto : IDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
