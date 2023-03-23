using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Restaurant_MVC.Models;
using System.Xml.Linq;

namespace Restaurant_MVC.Controllers
{
    public class RestaurantController : Controller
    {
        public List<Cuisine> Cuisines = new List<Cuisine>()
        {
           new Cuisine() {Id = 1, Name ="Française"},
           new Cuisine() {Id = 2, Name ="Marocaine"},
           new Cuisine() {Id = 3, Name ="Italienne"}
        };
        private static List<Restaurant> restaurants = new List<Restaurant>()   {
                new Restaurant
                {
                    Id= 1,
                    Name= "Olyon",
                    Location = "Tucson",
                    Cuisines = new List<Cuisine> {
                        new Cuisine { Id = 1, Name = "Française"},
                        new Cuisine { Id = 2, Name = "Marocaine" }},

                }  ,
                new Restaurant
                {
                    Id= 2,
                    Name= "Macdo",
                    Location = "Maroc",
                    Cuisine ="france",
                    Cuisines = new List<Cuisine> {
                        new Cuisine { Id = 1, Name = "Française"},
                        new Cuisine { Id = 2, Name = "Marocaine" }},

                }
      };

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.restaurant= GetAll();
            return View();
        }
     
        public ActionResult Create()
        {  
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant model)
        {
            restaurants.Add(model);
            ViewBag.model = Cuisines;
            return RedirectToAction("Index");
        }
     
        public ActionResult Edit(int id)
        {
            var  model = restaurants.Where(r=> r.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant res)
        {
            var model = restaurants.FirstOrDefault(r => r.Id == res.Id);
            restaurants.Remove(model);
            restaurants.Add(res);
            return RedirectToAction("Index");
        }

        [Route("/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var model = restaurants.Where(r => r.Id == id).FirstOrDefault();
            return View(model);
        }

        [Route("/Delete/{id}")]
        public IActionResult Delete(int id)
        { 
            Restaurant itemToRemove = restaurants.FirstOrDefault(r=> r.Id==id);
            var model = restaurants.Remove(itemToRemove);
             return RedirectToAction("Index"); 
        }
        public List<Restaurant> GetAll()
        {
            return restaurants; 
        }
    }
}
