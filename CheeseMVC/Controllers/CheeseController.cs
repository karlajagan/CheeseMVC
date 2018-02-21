using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public static List<Cheese> cheeses = new List<Cheese>();
        //static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
       
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            ViewBag.cheeses = cheeses;
            return View();
        }
        public IActionResult Add()
        {
            return View(); 
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            Cheese cheese = new Cheese(name, description);
            cheeses.Add(cheese);
            return Redirect("/Cheese");
        }

        public IActionResult Delete()
        {
            ViewBag.cheeses = cheeses;

            return View();
        }

        [HttpPost]
        [Route("/Cheese/DeleteSelected")]
        public IActionResult DeleteSelected(string[] cheeseSelect)
        {

            foreach  (Cheese cheesepiece in cheeses.ToList())         
            {
                foreach (string cheeseName in cheeseSelect) 
                {
                    if (cheesepiece.Name == cheeseName)
                    {
                        cheeses.Remove(cheesepiece);
                    }
                }
            }

            ViewBag.cheeses = cheeses;           

            return Redirect("/Cheese");
        }

        [HttpPost]
        [Route("/Cheese/DeleteAll")]
        public IActionResult DeleteAll(string[] cheeseSelect)
        {
            List<Cheese> cheeseList = new List<Cheese>(cheeses);

            foreach (Cheese cheese in cheeseList)
            {
                cheeses.Remove(cheese);
            }

            ViewBag.cheeses = cheeses;
            return Redirect("/Cheese");
        }
    }
}
