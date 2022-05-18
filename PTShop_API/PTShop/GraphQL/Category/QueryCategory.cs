using PTShop.Models;
using HotChocolate.Data;

namespace PTShop.GrapQL.Category
{
    [ExtendObjectType("Query")]
    public class QueryCategory
    {
        [UseDbContext(typeof(DatabaseContext))]
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.Category> GetCategory ([ScopedService] DatabaseContext context)
        {
            IQueryable<Models.Category> query = context.Categories.AsQueryable();
            return query;
        }
    }
}
