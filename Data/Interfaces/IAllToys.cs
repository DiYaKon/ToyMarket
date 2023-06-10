using System.Collections.Generic;
using ToyMarket.Data.Models;

namespace ToyMarket.Data.Interfaces
{
    public interface IAllToys
    {
        //функція повертає всі товари
        IEnumerable <Toy> Toys { get; }
        //функція повертає всі товари у яких isFavorite = true
        IEnumerable<Toy> getFavToys { get; }
        //повертає товар за його id
        Toy getObjectToys(int toyId);
    }
}
