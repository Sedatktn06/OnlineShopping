using Microsoft.EntityFrameworkCore;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Persistence.Context;

public class OrderContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-SATO7G7;initial Catalog=OnlineShoppingDiscountDb;integrated Security=true"); 
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OnlineShopping.Order.Domain.Entities.Order> Orders { get; set; }
}
