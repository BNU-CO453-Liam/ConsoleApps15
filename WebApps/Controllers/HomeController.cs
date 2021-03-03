using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApps.Models;
using ConsoleAppProject.App02;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DistanceConverter()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BmiCalculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BmiCalculator(BmiCalculator bmi)
        {
            if (bmi.UnitType == "Imperial")
            {
                bmi.CalculateImperial();
            }
            
            else if (bmi.UnitType == "Metric")
            {
                bmi.CalculateMetric();
            }

            else
            {
                //Error;
            }

            int bmiIndex = bmi.BmiResult;

            return RedirectToAction("HealthMessage", new { bmiIndex });


        }

        public IActionResult HealthMessage(int bmiIndex)
        {
            return View(bmiIndex);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
