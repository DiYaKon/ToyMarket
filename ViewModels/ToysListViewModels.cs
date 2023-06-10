using System.Collections.Generic;
using ToyMarket.Data.Models;

namespace ToyMarket.ViewModels
{
    public class ToysListViewModels
    {
        //поле, що збергіає всі товари
        public IEnumerable<Toy> allToys { get; set; }
        //зберігає поточну категорію
        public string currCategory { get; set; }

    }
}
