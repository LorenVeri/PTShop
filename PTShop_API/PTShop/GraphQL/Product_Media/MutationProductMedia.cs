using PTShop.Models;

namespace PTShop.GrapQL.Product_Media
{
    [ExtendObjectType("Mutation")]
    public class MutationProductMedia
    {
        [UseDbContext(typeof(DatabaseContext))]
        public Models.ProductMedium AddProductMedia([ScopedService] DatabaseContext context, ProductMediaType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ProductMedium>(item.input);
            var id = obj.Id;
            if (id == 0)
            {
                var productMedia = new Models.ProductMedium
                {
                    ProductId = obj.ProductId,
                    Uri = obj.Uri
                };
                context.ProductMedia.Add(productMedia);
                context.SaveChanges();
                return productMedia;
            }else
            {
                var productMedia = context.ProductMedia.Find(id);
                productMedia.ProductId = obj.ProductId;
                productMedia.Uri = obj.Uri;
                context.SaveChanges();
                return productMedia;
            }
        }

        [UseDbContext(typeof(DatabaseContext))]
        public bool DeleteProductMedia([ScopedService] DatabaseContext context, ProductMediaType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ProductMedium>(item.input);
            var id = obj.Id;
            if (id > 0)
            {
                var productMedia = context.ProductMedia.Find(id);
                context.ProductMedia.Remove(productMedia);
                context.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }
    }
}
