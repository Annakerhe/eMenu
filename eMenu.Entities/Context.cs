
using Microsoft.EntityFrameworkCore;
using eMenu.Entities.Models;

namespace eMenu.Entities;
public class Context : DbContext
{
    public DbSet <User> Users { get; set; }
    public DbSet <Table> Tables { get; set; }
    public DbSet <Order> Orders { get; set; }
    public DbSet <Dish> Dishes { get; set; }
    public DbSet <DishInOrder> DishesInOrders { get; set; }

     public Context(DbContextOptions<Context> options) : base(options) { }
     protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(x => x.Id);
        #endregion
        
        #region Tables
        builder.Entity<Table>().ToTable("Tables");
        builder.Entity<Table>().HasKey(x => x.Id);
        #endregion


        #region Orders
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(x => x.Id);
        builder.Entity<Order>().HasOne(x=>x.Table)
                               .WithMany(x=>x.Orders)
                               .HasForeignKey(x=>x.TableId)
                               .OnDelete(DeleteBehavior.Restrict);
        
        #endregion  


        #region Dishes
        builder.Entity<Dish>().ToTable("Dishes");
        builder.Entity<Dish>().HasKey(x => x.Id);                              
        #endregion           


        #region  DishesInOrders
        builder.Entity<DishInOrder>().ToTable("Dishes_in_orders");
        builder.Entity<DishInOrder>().HasKey(x => x.Id);

        builder.Entity<DishInOrder>().HasOne(x=>x.Dish)
                                     .WithMany(x=>x.DishesInOrders)
                                     .HasForeignKey(x=>x.DishId)
                                     .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<DishInOrder>().HasOne(x=>x.Order)
                                     .WithMany(x=>x.DishesInOrders)
                                     .HasForeignKey(x=>x.OrderId)
                                     .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }

}