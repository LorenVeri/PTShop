using PTShop.Models;

namespace PTShop.GrapQL.Product
{
    [ExtendObjectType("Query")]
    public class QueryProduct
    {
        [UseDbContext(typeof (DatabaseContext))]
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.Product> GetProduct([ScopedService] DatabaseContext context)
        {
            IQueryable < Models.Product > query = context.Products.AsQueryable();
            return query;
        }
    }
}
