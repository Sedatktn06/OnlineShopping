using Microsoft.Extensions.Options;
using OnlineShopping.Catalog.DbSettings;
using OnlineShopping.Catalog.Repository;
using OnlineShopping.Catalog.Services.CategoryServices;
using OnlineShopping.Catalog.Services.ProductDetailServices;
using OnlineShopping.Catalog.Services.ProductImageServices;
using OnlineShopping.Catalog.Services.ProductServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductDetailService,ProductDetailService>();
builder.Services.AddScoped<IProductImageService,ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp=>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
