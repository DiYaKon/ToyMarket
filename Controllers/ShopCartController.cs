using ToyMarket.Data.Models;
using Microsoft.AspNetCore.Mvc;
using ToyMarket.ViewModels;
using System.Linq;
using ToyMarket.Data.Interfaces;

namespace ToyMarket.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllToys _toyRep;//змінна для репозиторію (БД)
        private readonly ShopCart _shopCart;//змінна для кошика

        public ShopCartController(IAllToys toyRep, ShopCart shopCart)
        {
            _toyRep = toyRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() //ф.к для визову html шаблону
        {
            var items = _shopCart.getShopItems(); //отримання усіх товарів
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModels
            {
                shopCart = _shopCart
            };
            return View(obj);
        }

        //для переадресації на іншу сторінку
        public RedirectToActionResult addToCart(int id)
        {
            var item = _toyRep.Toys.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}