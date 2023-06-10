using System.Collections.Generic;
using ToyMarket.Data.Models;

namespace ToyMarket.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Toy> favToys { get; set; }
    }
}
