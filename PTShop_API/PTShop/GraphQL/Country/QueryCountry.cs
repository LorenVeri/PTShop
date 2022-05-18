using PTShop.Models;

namespace PTShop.GrapQL.Country
{
    [ExtendObjectType("Query")]
    public class QueryCountry
    {
        [UseDbContext(typeof(DatabaseContext))]
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.Country> GetCountry([ScopedService] DatabaseContext context)
        {
            IQueryable<Models.Country> query = context.Countries.AsQueryable();
            return query;
        }
    }
}
