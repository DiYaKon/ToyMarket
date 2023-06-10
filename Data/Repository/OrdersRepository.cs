using System;
using ToyMarket.Data.Interfaces;
using ToyMarket.Data.Models;

namespace ToyMarket.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = shopCart.listShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    toyID = el.toy.id,
                    orderID = order.id,
                    price = el.toy.price
                };
                appDBContent.OrderDetail.Add(orderDetail); //додання інфи до бд
            }
            appDBContent.SaveChanges(); //збереження в бд
        }
    }
}
