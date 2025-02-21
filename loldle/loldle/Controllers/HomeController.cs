using Microsoft.AspNetCore.Mvc;
using loldle.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using loldle.Data;

namespace loldle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var randomQuote = _context.Quotes
                .OrderBy(q => Guid.NewGuid())
                .FirstOrDefault();
            return View(randomQuote);
        }

        [HttpPost]
        public IActionResult CheckAnswer(int id, string userAnswer)
        {
            var quote = _context.Quotes.FirstOrDefault(q => q.Id == id);
            if (quote != null && quote.Answer.Equals(userAnswer, StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Message = "Success!";
            }
            else
            {
                ViewBag.Message = "Try again!";
            }

            var newRandomQuote = _context.Quotes
                .OrderBy(q => Guid.NewGuid())
                .FirstOrDefault();
            return View("Index", newRandomQuote);
        }
    }
}
