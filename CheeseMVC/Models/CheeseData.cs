using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        public static List<Cheese> cheeses = new List<Cheese>();

        // Get all
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        // Add
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // Delete
        public static void Delete(int id)
        {
            Cheese cheeseToDelete = GetById(id);
            cheeses.Remove(cheeseToDelete);
        }

        // GetById
        public static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.CheeseId == id);
        }
    }
}
