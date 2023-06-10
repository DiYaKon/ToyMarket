using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToyMarket.Data.Interfaces;
using ToyMarket.Data.Models;
using ToyMarket.ViewModels;

namespace ToyMarket.Controllers
{
    public class ToysController : Controller
    {
        private readonly IAllToys _allToys;
        private readonly IToysCategory _allCatagories;

        public ToysController(IAllToys iAllToys, IToysCategory iToysCateory)
        {
            _allToys = iAllToys;
            _allCatagories = iToysCateory;
        }

        //функціяя що повретає html-сторінку
        [Route("Toys/List")] //адреси, при переході на які, буде спрацьовувати функція
        [Route("Toys/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Toy> toys = null; //потрібно щоб компілятор не матюкався на відсутність використання toys
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                toys = _allToys.Toys.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("doll", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Лялька")).OrderBy(i => i.id);
                    currCategory = "Лялька";
                }
                else if (string.Equals("soft", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("М'яка іграшка")).OrderBy(i => i.id);
                    currCategory = "М'яка іграшка";
                }
                else if (string.Equals("construction", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Конструктор")).OrderBy(i => i.id);
                    currCategory = "Конструктор";
                }
                else if (string.Equals("car", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Машинка")).OrderBy(i => i.id);
                    currCategory = "Машинка";
                }
                else if (string.Equals("board", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Настільна гра")).OrderBy(i => i.id);
                    currCategory = "Настільна гра";
                }
                else if (string.Equals("puzzle", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Пазл")).OrderBy(i => i.id);
                    currCategory = "Пазл";
                }
                else if (string.Equals("educational", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Розвивальна іграшка")).OrderBy(i => i.id);
                    currCategory = "Розвивальна іграшка";
                }
                else if (string.Equals("lego", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    toys = _allToys.Toys.Where(i => i.Category.categoryName.Equals("Конструктор LEGO")).OrderBy(i => i.id);
                    currCategory = "Конструктор LEGO";
                }
            }

            var toyObj = new ToysListViewModels
            {
                allToys = toys,
                currCategory = currCategory
            };

            ////дані, що будть передані на сторінку
            //створюємо об'єкт для передачі в шаблон
            ViewBag.Title = "Іграшки";
            return View(toyObj);//передача об'єкта в шаблон
        }
    }
}
