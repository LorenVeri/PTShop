﻿using PTShop.Models;

namespace PTShop.GrapQL.Product_Price
{
    [ExtendObjectType("Mutation")]
    public class MutationProductPrice
    {
        [UseDbContext(typeof(DatabaseContext))]
        public Models.ProductPrice AddProductPrice([ScopedService] DatabaseContext context, ProductPriceType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ProductPrice>(item.input);
            var id = obj.Id;
            if (id == 0)
            {
                var productPrice = new Models.ProductPrice
                {
                    ProductId = obj.ProductId,
                    CreatedAt = DateTime.Now,
                    Price = obj.Price,
                };
                context.ProductPrices.Add(productPrice);
                context.SaveChanges();
                return productPrice;
            }
            else
            {
                var productPrice = context.ProductPrices.Find(id);
                productPrice.ProductId = obj.ProductId;
                productPrice.CreatedAt = DateTime.Now;
                productPrice.Price = obj.Price;
                context.SaveChanges();
                return productPrice;
            }
        }

        [UseDbContext(typeof(DatabaseContext))]
        public bool DeleteProductPrice([ScopedService] DatabaseContext context, ProductPriceType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ProductPrice>(item.input);
            var id = obj.Id;
            if (id > 0)
            {
                var productPrice = context.ProductPrices.Find(id);
                context.ProductPrices.Remove(productPrice);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
