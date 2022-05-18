using Microsoft.EntityFrameworkCore;
using PTShop.GrapQL.Category;
using PTShop.GrapQL.Country;
using PTShop.GrapQL.Product;
using PTShop.GrapQL.Product_Media;
using PTShop.GrapQL.Product_Price;
using PTShop.Models;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddPooledDbContextFactory<DatabaseContext>(o => o.UseSqlServer(connectionString));
//Scaffold-DbContext "Server=DESKTOP-AMJ7HPS;Database=PTSHOP;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DatabaseContext -force
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
            });
});

builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


builder.Services
        .AddGraphQLServer()
        .AddQueryType(x => x.Name("Query"))
            .AddTypeExtension<QueryCategory>()
            .AddTypeExtension<QueryCountry>()
            .AddTypeExtension<QueryProduct>()
            .AddTypeExtension<QueryProductPrice>()
            .AddTypeExtension<QueryProductMedia>()
        .AddMutationType(x => x.Name("Mutation"))
            .AddTypeExtension<MutationCategory>()
            .AddTypeExtension<MutationCountry>()
            .AddTypeExtension<MutationProduct>()
            .AddTypeExtension<MutationProductPrice>()
            .AddTypeExtension<MutationProductMedia>()
        .AddProjections()
        .AddFiltering()
        .AddSorting();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.MapGraphQL("/graphql");
app.UseCors(MyAllowSpecificOrigins);
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

app.Run();
