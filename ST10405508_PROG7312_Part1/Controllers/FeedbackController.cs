using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Controllers
{
    public class FeedbackController : Controller
    {
        //Adding the interfaces (Teddy Smith, 2022):
        private readonly IFeedbackInterface _feedbackRepo;
        private readonly IDocumentInterface _documentInterface;

        public FeedbackController(IFeedbackInterface feedbackRepo, IDocumentInterface documentInterface)
        {
            _feedbackRepo = feedbackRepo;
            _documentInterface = documentInterface;
        }

        // Show form to add feedback
        public IActionResult AddFeedback()
        {
            return View();
        }

        // Handle feedback submission
        [HttpPost]
        public async Task<IActionResult> AddFeedback(Feedback feedback, IFormFile? documentFile)
        {
            //fethcing the users id from the current context (Anderson, Larkin & LaRose, 2025):
            if (HttpContext.Session.GetString("uID") == "" || HttpContext.Session.GetString("uID") == null)
            {
                ViewBag.ErrorMsg = "Must Sign in First!";
                return View();
            }
            ViewBag.SuccessMsg = null;
            try
            {
                if (!string.IsNullOrEmpty(feedback.title) && !string.IsNullOrEmpty(feedback.description))
                {
                    
                    //Storing the user info and feedback (Anderson, Larkin & LaRose, 2025; Teddy Smith, 2022):
                    feedback.userID = HttpContext.Session.GetString("uID");
                    //creating new unique key for feedbackid (MicrosoftLearn, 2025):
                    feedback.feedbackID = Guid.NewGuid().ToString();
                    feedback.date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    feedback.status = "Pending";
                    //adding the user to the database (Teddy Smith, 2022):
                    bool added = _feedbackRepo.Add(feedback);

                    return RedirectToAction("ViewFeedback");

                }
                ViewBag.ErrorMsg = "All Fields are required!";
                return View(feedback);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }

        // Show all feedbacks for the logged-in user (Teddy Smith, 2022):
        public async Task<IActionResult> ViewFeedback()
        {
            //Getting the specific users feedbacks through the db and their ID (Anderson, Larkin & LaRose, 2025; Teddy Smith, 2022):
            string userId = HttpContext.Session.GetString("uID");
            var allFeedbacks = await _feedbackRepo.GetUserFeedback(userId);
           

            return View(allFeedbacks);
        }

    }
}
//reference List: 

//Anderson, R., Larkin, K. And LaRose, D. 2025. Session and state management in ASP.NET Core, 24 April 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0 [Accessed 6 September 2025].

//MicrosoftLearn. 2025. Upload files in ASP.NET Core, 9 August 2024. [Online]. Avaliable at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-8.0  [Accessed 8 September 2025].

//MicrosoftLearn. 2025. Guid.NewGuid Method. [Online]. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=net-9.0 [Accessed 8 September 2025].

//Teddy Smith, 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online] Available at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=7 [Accessed 7 September 2025].