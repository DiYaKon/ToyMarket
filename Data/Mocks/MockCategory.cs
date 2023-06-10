using ToyMarket.Data.Interfaces;
using System.Collections.Generic;
using ToyMarket.Data.Models;
namespace ToyMarket.Data.Mocks
{
    public class MockCategory : IToysCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> 
                {
                    new Category {categoryName = "Лялька", desc =
                    "Іграшка у вигляді людини, зазвичай із рухомими кінцівками та різними аксесуарами."},
                    new Category {categoryName = "М'яка іграшка",
                    desc = "Плюшева іграшка, виконана з м'якого матеріалу."},
                    new Category {categoryName = "Конструктор",
                    desc = "Набір різнокольорових блоків або елементів, які можна з'єднувати та створювати різні конструкції."},
                    new Category {categoryName = "Машинка",
                    desc = "Мініатюрна іграшкова машина, що представляє різні види транспорту, такі як автомобілі, вантажівки або пожежні машини."},
                    new Category {categoryName = "Настільна гра",
                    desc = "Гра, яку грають на спеціальному ігровому полі або на дошці, яка зазвичай вимагає участі кількох гравців."},
                    new Category {categoryName = "Пазл",
                    desc = "Гра-головоломка, що складається з різних фрагментів, які потрібно правильно з'єднати, щоб отримати зображення."},
                    new Category {categoryName = "Розвивальна іграшка",
                    desc = "Іграшка, спеціально розроблена для розвитку навичок і умінь у дітей, таких як логіка, моторика або мова."},
                    new Category {categoryName = "Конструктор LEGO",
                    desc = "Іграшковий набір, що складається з безлічі маленьких деталей, за допомогою яких можна збирати різні моделі та конструкції."},
                };
            }
        }
    }
}
