using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToyMarket.Data.Interfaces;
using ToyMarket.Data.Models;

namespace ToyMarket.Data.Repository
{
    public class CategoryRepository : IToysCategory
    {
        //змінна для роботи з класом налаштувань БД AppDBContext.cs
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
