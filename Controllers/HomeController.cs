using ToyMarket.Data.Models;
using Microsoft.AspNetCore.Mvc;
using ToyMarket.ViewModels;
using System.Linq;
using ToyMarket.Data.Interfaces;

namespace ToyMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllToys _toyRep;//змінна для репозиторію (БД)
        public HomeController(IAllToys toyRep)
        {
            _toyRep = toyRep;
        }
        public ViewResult Index()
        {
            var homeToys = new HomeViewModel
            {
                favToys = _toyRep.getFavToys
            };
            return View(homeToys);
        }
    }
}
