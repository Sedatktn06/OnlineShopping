using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Discount.Entities;
using System.Data;

namespace OnlineShopping.Discount.Context;

public class DapperContext:DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-SATO7G7;initial Catalog=OnlineShoppingDiscountDb;integrated Security=true");
    }

    public DbSet<Coupon> Coupons { get; set; }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
