namespace Ecommerce.Models
{
    public interface IGridFilters
    {
        int PageSize { get; set; }
        int PageNo { get; set; }
    }

    public class GridFilters : IGridFilters
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
    }
}
