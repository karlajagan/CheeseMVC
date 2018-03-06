using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
       
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "List of Cheeses";
            List<Cheese> cheeses = CheeseData.GetAll();
            return View(cheeses);
        }
        public IActionResult Add()
        {
            ViewBag.title = "Add Cheese";
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            ViewBag.title = "Add Cheese";
            return View(addCheeseViewModel); 
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description
                };

                CheeseData.Add(newCheese);
                ViewBag.title = "Add Cheese";
                return Redirect("/Cheese");
            }
            return View(addCheeseViewModel);
            
        }

        public IActionResult Delete()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            ViewBag.title = "Delete Cheeses";

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

        public IActionResult Edit(int CheeseId)
        {
            ViewBag.title = "Edit Cheese";
            ViewBag.thisCheese = CheeseData.GetById(CheeseId);
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Edit")]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            Cheese thisCheese = new Cheese();
            thisCheese.CheeseId = cheeseId;
            thisCheese.Name = name;
            thisCheese.Description = description;
            CheeseData.Update(thisCheese);
            return Redirect("/Cheese");
        }


    }
}
