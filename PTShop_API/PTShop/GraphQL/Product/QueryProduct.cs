using PTShop.GraphQL.Product;
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
        public IQueryable<Models.Product> SearchProduct([ScopedService] DatabaseContext context, SearchInput item)
        {
            IQueryable < Models.Product > query = context.Products.AsQueryable();
            if(item.Name.Length > 0)
            {
                query = query.Where(x => x.Name.Contains(item.Name));
                return query;
            } 
            if(item.Status == true)
            {
                query = query.Where(x => x.Status == item.Status);
                return query;
            }
            if (item.Sale == true)
            {
                query = query.Where(x => x.Sale == item.Sale);
            }
            if (item.IsDelete == true)
            {
                query = query.Where(x => x.Sale == item.IsDelete);
            }
            return query;
        }

        [UseDbContext(typeof(DatabaseContext))]
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.Product> GetProduct([ScopedService] DatabaseContext context)
        {
            IQueryable<Models.Product> query = context.Products.AsQueryable();
            return query;
        }
    }
}
