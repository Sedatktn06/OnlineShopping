using Microsoft.EntityFrameworkCore;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Persistence.Context;

public class OrderContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=OnlineShoppingOrderDb;User=sa;Password=KrossingOver159"); 
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OnlineShopping.Order.Domain.Entities.Order> Orders { get; set; }
}
