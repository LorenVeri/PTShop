using PTShop.Models;

namespace PTShop.GrapQL.Product
{
    [ExtendObjectType("Mutation")]
    public class MutationProduct
    {
        [UseDbContext(typeof (DatabaseContext))]
        public Models.Product AddProduct([ScopedService] DatabaseContext context, ProductType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Product>(item.input);
            var id = obj.Id;
            if (id == 0)
            {
                var product = new Models.Product
                {
                    Name = obj.Name,
                    Description = obj.Description,
                    MadeIn = obj.MadeIn,
                    Price = obj.Price,
                    CategoryId = obj.CategoryId,
                    IsDelete = obj.IsDelete,
                    Status = obj.Status,
                    CreateAt = DateTime.Now,
                    ManufacturerId = obj.ManufacturerId,
                    UpdateAt = DateTime.Now
                };

                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            else
            {
                var product = context.Products.FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return null;
                } else
                {
                    product.Name = obj.Name;
                    product.Description = obj.Description;
                    product.MadeIn = obj.MadeIn;
                    product.Price = obj.Price;
                    product.UpdateAt = DateTime.Now;
                    product.CategoryId = obj.CategoryId;
                    product.IsDelete = obj.IsDelete;
                    product.Status = obj.Status;
                    product.ManufacturerId = obj.ManufacturerId;
                }
                context.SaveChanges();
                return product;
            }

        }
    
        [UseDbContext(typeof (DatabaseContext))]
        public bool DeleteProject([ScopedService] DatabaseContext context, ProductType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Product>(item.input);
            var id = obj.Id;
            if(id > 0)
            {
                var product = context.Products.FirstOrDefault(p => p.Id == id);

                context.Products.Remove(product);
                return true;
            }else
            {
                return false;
            }
        }
    }
}
