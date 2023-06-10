using Microsoft.EntityFrameworkCore;
using ToyMarket.Data.Models;

namespace ToyMarket.Data
{// Тут у нас налаштування щодо пі'єднання до БД
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        //які таблички будуть створені у БД
        public DbSet<Toy> Toy { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        //після кожних змін БД треба його оновляти за допомоги PAckage Manager Console
        //EntityFrameworkCore\Add-Migration Orders
        //EntityFrameworkCore\Update-database
    }
}
