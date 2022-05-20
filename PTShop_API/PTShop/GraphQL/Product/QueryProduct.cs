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
            if(item.name.Length > 0)
            {
                query = query.Where(x => x.Name == item.name);
                return query;
            } 
            if(item.status.ToString().Length > 0)
            {
                query = query.Where(x => x.Status == item.status);
                return query;
            }
            //if(item.sale.ToString().Length == 0)
            //{
            //    query = query.Where(x => x.Sale == item.sale);
            //}
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
