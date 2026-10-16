using Microsoft.AspNetCore.Mvc;
using CarRentalApp.Models;
using System.Collections.Generic;

namespace CarRentalApp.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000m },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000m },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000m }
        };

        private static List<Car> bookedCars = new List<Car>();
        public IActionResult Index()
        {
            return View(availableCars);
        }
        [HttpPost]
        public IActionResult Book(int id)
        {
            Car? car = availableCars.Find(c => c.Id == id);

            if (car == null)
            {
                return RedirectToAction("Index");
            }

            availableCars.Remove(car);
            bookedCars.Add(car);

            return RedirectToAction("Booked");
        }
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }

}