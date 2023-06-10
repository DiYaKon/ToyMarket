using ToyMarket.Data.Interfaces;
using ToyMarket.Data.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ToyMarket.Data.Mocks
{
    public class MockToys : IAllToys
    {
        private readonly IToysCategory _categoryToys = new MockCategory();
        public IEnumerable<Toy> Toys
        {
            get
            {
                return new List<Toy> 
                {
                    new Toy 
                    {
                        name = "Our Generation Піа",
                        shortDesc = "46 см",
                        longDesc="з довгим волоссям блонд 46 см",
                        img="/img/1.jpg",
                        price=1259,
                        isFavourite=true,
                        available=true,
                        Category = _categoryToys.AllCategories.First()
                    },
                    new Toy 
                    {
                        name = "Лялька Barbie Фруктовий сюрприз",
                        shortDesc = "Кольорове перевтілення",
                        longDesc = "Лялька Barbie Фруктовий сюрприз Кольорове перевтілення",
                        img = "/img/2.jpg",
                        price = 899,
                        isFavourite = false,
                        available = true,
                        Category = _categoryToys.AllCategories.First()
                    },
                    new Toy
                    {
                        name = "Сокіл Тисячоліття Millennium Falcon",
                        shortDesc = "Конструктор LEGO Star Wars Сокіл Тисячоліття",
                        longDesc = "Легендарний «Сокіл тисячоліття» серії LEGO Star Wars щойно приземлився! Супершвидкий кореліанський зореліт Хана Соло складається з 7500 елементів і має круті деталі та класні функції. Тебе вразять витончені нюанси корпуса, тарілка антени, верхні та нижні чотиридульні лазерні гармати, 7 шасі, вантажний пандус, що опускається, та прихована бластерна гармата.",
                        img = "/img/3.jpg",
                        price = 30079,
                        isFavourite = false,
                        available = false,
                        Category = _categoryToys.AllCategories.Last()
                    },
                    new Toy
                    {
                        name = "LEGO Super Mario Nintendo",
                        shortDesc = "Конструктор LEGO Super Mario Nintendo Entertainment System 2646 деталей",
                        longDesc = "Відтвори класичний геймплей Super Mario Bros. за допомогою цієї крутої Розважальної системи LEGO Nintendo. Установи Архів із грою на консоль, складену з кубиків. Поверни ручку ретротелевізора, щоб побачити на екрані восьмибітного Маріо. Потім помісти фігурку Маріо LEGO (не входить до комплекту) у спеціальний відсік нагорі, щоб поспостерігати, як він реагує на різних ворогів, перешкоди та посилення, що з'являються на екрані, і послухати оригінальну музику з гри.Пробудіть ностальгічні спогади, створюючи цей чудово пророблений кубик LEGO Nintendo Entertainment System (71374) й інтерактивний телевізор у стилі 1980-х, що демонструє класичну гру Super Mario Bros. Телевізор має екран прокручування, керований ручкою, і якщо ви проскануєте кубик дій, помістивши LEGO Mario (малюнок не входить до комплекту) у проріз згори, він реагуватиме на ворогів на екрані, перешкоди й бонуси. Справжні деталі консолі NES відтворені в стилі LEGO, включно з контролером і отвором для складання Game Pak із реалістичною функцією блокування, щоб потішити шанувальників Super Mario Bros.",
                        img = "/img/4.webp",
                        price = 9999,
                        isFavourite = true,
                        available = true,
                        Category = _categoryToys.AllCategories.Last()
                    },
                    new Toy
                    {
                        name = "LEGO Classic Скринька для творчості",
                        shortDesc = "Конструктор LEGO Classic Скринька для творчості 213 деталей",
                        longDesc = "LEGO Classic допоможе вам розвинути у своїй дитині бажання творити. З яскравими, кольоровими, універсальними кубиками LEGO будь-яка творча гра стає простішою. Кожен набір містить класичні кубики LEGO, комплект спеціальних елементів і добірку ідей, щоб допомогти долучитися до гри. Тепер у вашої дитини є все, що потрібно їй для натхнення. У міру того, як діти вдосконалюватимуть свої навички складання, вони навчаться збирати, що завгодно: будинку, машини та тварин. А оскільки кубики LEGO Classic підходять для різних вікових груп, конструювання може стати розвагою для всієї сім'ї й розбудити уяву кожного з поколінь.",
                        img = "/img/5.webp",
                        price = 560,
                        isFavourite = true,
                        available = false,
                        Category = _categoryToys.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Toy> getFavToys { get; set; }

        public Toy getObjectToys(int toyId)
        {
            throw new NotImplementedException();
        }
    }
}
