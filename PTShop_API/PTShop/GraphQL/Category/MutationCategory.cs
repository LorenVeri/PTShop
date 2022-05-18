using PTShop.Models;

namespace PTShop.GrapQL.Category
{
    [ExtendObjectType("Mutation")]
    public class MutationCategory
    {
        [UseDbContext(typeof(DatabaseContext))]
        public Models.Category AddCategory([ScopedService] DatabaseContext context, CategoryType item)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Category>(item.input); 
            var id = obj.Id;
            if(id == 0)
            {
                var category = new Models.Category()
                {
                    Name = obj.Name,
                    ParentId = obj.ParentId,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };

                context.Categories.Add(category);
                context.SaveChanges();
                return category;
            }else
            {
                var categoy = context.Categories.FirstOrDefault(c => c.Id == id);
                if(categoy == null)
                {
                    return null;
                }else
                {
                    categoy.Name = obj.Name;
                    categoy.ParentId = obj.ParentId;
                    categoy.UpdateAt = DateTime.Now;
                    context.SaveChanges();
                    return categoy;
                }
            }
        }

        [UseDbContext(typeof(DatabaseContext))]
        public bool DeleteCategory([ScopedService] DatabaseContext context, CategoryType item) 
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Category>(item.input);
            var id = obj.Id;
            if(id > 0)
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == id);
                context.Categories.Remove(category);
                context.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }
    }
}
