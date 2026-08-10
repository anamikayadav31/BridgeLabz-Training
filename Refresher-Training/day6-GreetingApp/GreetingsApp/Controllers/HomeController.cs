using Microsoft.AspNetCore.Mvc;
using GreetingsApp.Models;

namespace GreetingsApp.Controllers
{
    public class HomeController : Controller
    {
        // Show page
        [HttpGet]
        public IActionResult Index()
        {
            GreetingModel model = new GreetingModel();

            model.TimeOfDay = GetTimeOfDay();

            return View(model);
        }

        // Handle form
        [HttpPost]
        public IActionResult Index(GreetingModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                model.Message = "Please enter your name first!";
                model.TimeOfDay = GetTimeOfDay();

                return View(model);
            }

            string time = GetTimeOfDay();

            model.Message =
                $"Good {time}, {model.Name}! Welcome to My Greetings App.";

            model.TimeOfDay = time;

            return View(model);
        }

        // Get time
        private string GetTimeOfDay()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 5 && hour < 12)
                return "Morning";

            else if (hour >= 12 && hour < 17)
                return "Afternoon";

            else if (hour >= 17 && hour < 21)
                return "Evening";

            else
                return "Night";
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}