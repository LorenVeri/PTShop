using PTShop.Models;

namespace PTShop.GrapQL.Product_Media
{
    [ExtendObjectType("Query")]
    public class QueryProductMedia
    {
        [UseDbContext(typeof(DatabaseContext))]
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.ProductMedium> GetProductMedia([ScopedService] DatabaseContext context)
        {
            IQueryable<Models.ProductMedium> query = context.ProductMedia.AsQueryable();
            return query;
        }
    }
}
