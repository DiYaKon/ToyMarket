using System.Collections.Generic;
using ToyMarket.Data.Models;

namespace ToyMarket.Data.Interfaces
{
    public interface IToysCategory
    {
        IEnumerable <Category> AllCategories { get; }
    }
}
