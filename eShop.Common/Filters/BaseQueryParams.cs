using eShop.Common.Filters.Interfaces;

namespace eShop.Common.Filters
{
    public class BaseQueryParams : IBaseQueryParams
    {
        public string OrderBy { get; set ; }
    }
}
