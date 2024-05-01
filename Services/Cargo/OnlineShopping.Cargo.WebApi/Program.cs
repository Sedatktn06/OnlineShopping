using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnlineShopping.Cargo.BusinessLayer.Abstract;
using OnlineShopping.Cargo.BusinessLayer.Concrete;
using OnlineShopping.Cargo.DataAccessLayer.Abstract;
using OnlineShopping.Cargo.DataAccessLayer.Persistance;
using OnlineShopping.Cargo.DataAccessLayer.Repositories.EntityFramework;
using OnlineShopping.Cargo.DtoLayer.Mapping.CargoCompanyMappings;
using OnlineShopping.Cargo.DtoLayer.Mapping.CargoCustomerMappings;
using OnlineShopping.Cargo.DtoLayer.Mapping.CargoDetailMappings;
using OnlineShopping.Cargo.DtoLayer.Mapping.CargoOperationMappings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;
});

#region Registirations

builder.Services.AddDbContext<CargoContext>();
builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();

builder.Services.AddAutoMapper(typeof(CargoCustomerMapping));
builder.Services.AddAutoMapper(typeof(CargoDetailMapping));
builder.Services.AddAutoMapper(typeof(CargoOperationMapping));
builder.Services.AddAutoMapper(typeof(CargoCompanyMapping));

#endregion

// Add services to the container.

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
