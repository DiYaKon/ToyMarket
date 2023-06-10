using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToyMarket.Data.Interfaces;
using ToyMarket.Data.Models;

namespace ToyMarket.Data.Repository
{
    public class ToyRepository : IAllToys
    {
        //змінна для роботи з класом налаштувань БД AppDBContext.cs
        private readonly AppDBContent appDBContent;

        public ToyRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Toy> Toys => appDBContent.Toy.Include(c => c.Category);

        public IEnumerable<Toy> getFavToys => appDBContent.Toy.Where(p => p.isFavourite).Include(c => c.Category);

        public Toy getObjectToys(int toyId) => appDBContent.Toy.FirstOrDefault(p => p.id == toyId);
    }
}
