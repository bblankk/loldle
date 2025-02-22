using Microsoft.AspNetCore.Mvc;
using loldle.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using loldle.Data;

namespace loldle.Controllers
{
    public class ClassicModeController : Controller
    {
        private static List<string> wrongAnswers = new List<string>();

        private readonly ApplicationDbContext _context;

        public ClassicModeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var randomChampion = _context.Champion
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();

            if (randomChampion == null)
            {
                ViewBag.Message = "No champions found!";
                return View();
            }

            return View(randomChampion);
        }

        [HttpPost]
        public IActionResult CheckAnswer(int id, string userAnswer)
        {
            var champion = _context.Champion.FirstOrDefault(c => c.Id == id);
            if (champion != null && champion.Name.Equals(userAnswer, StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Message = "Success!";
                wrongAnswers.Clear();  // Clear wrong answers if the user guesses correctly
            }
            else
            {
                ViewBag.Message = "Try again!";
                if (!wrongAnswers.Contains(userAnswer))
                {
                    wrongAnswers.Add(userAnswer);
                }
            }

            ViewBag.WrongAnswers = wrongAnswers;

            var newRandomChampion = _context.Champion
                .OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();

            if (newRandomChampion == null)
            {
                ViewBag.Message = "No champions found!";
                return View("Index");
            }

            return View("Index", newRandomChampion);
        
     }
    }
}