using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourProjectNamespace.Models;

namespace YourProjectNamespace.Controllers
{
    public class InsureeController : Controller
    {
        private readonly YourDbContext _dbContext;

        public InsureeController(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateQuote(Insuree model)
        {
            decimal quote = 50; // Base quote

            // Apply pricing rules based on user inputs
            if (model.Age <= 18)
                quote += 100;
            else if (model.Age >= 19 && model.Age <= 25)
                quote += 50;
            else
                quote += 25;

            if (model.CarYear < 2000)
                quote += 25;
            else if (model.CarYear > 2015)
                quote += 25;

            if (model.CarMake == "Porsche")
            {
                quote += 25;
                if (model.CarModel == "911 Carrera")
                    quote += 25;
            }

            quote += 10 * model.SpeedingTickets;

            if (model.HasDUI)
                quote *= 1.25; // 25% increase for DUI

            if (model.CoverageType == "Full")
                quote *= 1.5; // 50% increase for full coverage

            model.Quote = quote; // Set the calculated quote in the model

            // Add the Insuree model to the database and save changes
            _dbContext.Insurees.Add(model);
            _dbContext.SaveChanges();

            // Redirect to the result view with Insuree's id
            return RedirectToAction("ResultView", new { id = model.Id });
        }

        public ActionResult AdminView()
        {
            List<Insuree> insurees = _dbContext.Insurees.ToList();
            return View(insurees);
        }
    }
}
