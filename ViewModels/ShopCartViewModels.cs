using ToyMarket.Data.Models;

namespace ToyMarket.ViewModels
{
    public class ShopCartViewModels
    {
        public ShopCart shopCart { get; set; }
    }
}
/*ViewModel потрібні для того щоб зберігати в них декілька значень, і потім передавати
 * в html-шаблон не декілька об'єктів, а один на основі ViewModel */