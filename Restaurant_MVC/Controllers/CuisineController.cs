using Microsoft.AspNetCore.Mvc;
using Restaurant_MVC.Models;

namespace Restaurant_MVC.Controllers
{
    public class CuisineController : Controller
    {
        public List<Cuisine> Cuisines = new List<Cuisine>()
        {
           new Cuisine() {Id = 1, Name ="Française"},
           new Cuisine() {Id = 2, Name ="Marocaine"},
           new Cuisine() {Id = 3, Name ="Italienne"}
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();

        }



    }
}
