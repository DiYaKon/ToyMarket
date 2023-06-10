using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToyMarket.Data.Models
{
    public class ShopCart
    {
        //змінна для роботи з класом налаштувань БД AppDBContext.cs (щоб працювало з БД)
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            //створюємо об'єкт для роботи з сессією
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //ствроюємо нову сессію
            var context = services.GetService<AppDBContent>(); //за допомого цього ми отримуємо різні таблички
            /*перевіряємо чи був створений кошик чи створюємо*/
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString(); //id кошика
                                      
            session.SetString("CartId", shopCartId); //присваюємо id кошика сессії
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        //функція додавання товару до кошика
        public void AddToCart(Toy toy)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                toy = toy,
                price = toy.price
            });
            appDBContent.SaveChanges();
        }
        //функція відображення товарів в кошику
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.toy).ToList();
        }

    }
}
