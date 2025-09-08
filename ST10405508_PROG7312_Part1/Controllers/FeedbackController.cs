using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeedback(Feedback feedback)
            {
            return View();
            }
    }
}
