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
       
        // GET: /<controller>/
        public IActionResult Index()
        {


            ViewBag.Title = "List of Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Add Cheese";
            return View(); 
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {           
            CheeseData.Add(newCheese);
            return Redirect("/Cheese");
        }

        public IActionResult Delete()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            ViewBag.Title = "Delete Cheeses";

            return View();
        }

        [HttpPost]
        [Route("/Cheese/DeleteSelected")]
        public IActionResult DeleteSelected(int[] cheeseSelect)
        {
            foreach (int cheeseId in cheeseSelect)
            {
                CheeseData.Delete(cheeseId);

            }
            ViewBag.cheeses = CheeseData.GetAll();           
            return Redirect("/Cheese");
        }

        [HttpPost]
        [Route("/Cheese/DeleteAll")]
        public IActionResult DeleteAll(string[] cheeseSelect)
        {
            List<Cheese> cheeseList = new List<Cheese>(CheeseData.GetAll());

            foreach (Cheese cheese in cheeseList)
            {
                CheeseData.Delete(cheese.CheeseId);
            }

            ViewBag.cheeses = CheeseData.GetAll();
            return Redirect("/Cheese");
        }
    }
}
