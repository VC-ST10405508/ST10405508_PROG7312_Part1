using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Controllers
{
    public class ReportIssueController : Controller
    {
        //read only fields for the data (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
        private readonly IReportIssuesInterface _reportIssueInterface;
        private readonly IUserInterface _userInterface;
        private readonly IDocumentInterface _documentInterface;
        private readonly ILogger<ReportIssueController> _logger;
        public string errMsg = "";
        public string successMsg = "";
        //constructor of this controller (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
        public ReportIssueController(IReportIssuesInterface reportIssueInterface, IUserInterface userInterface, IDocumentInterface documentInterface, ILogger<ReportIssueController> logger)
        {
            _reportIssueInterface = reportIssueInterface;
            _userInterface = userInterface;
            _documentInterface = documentInterface;
            _logger = logger;
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult addReport(ReportIssue report, byte[] documentFile)
        {
            //creating vars that will be used inside the view to display success or error (Geeksforgeeks, 2022):
            ViewBag.SuccessMsg = null;
            ViewBag.ErrorMsg = null;

            //setting ids to be unique for the database
            var documentID = "D" + _documentInterface.GetCount();
            var reportID = "R" + _reportIssueInterface.GetCount();
            report.reportID = reportID;
            report.documentID = documentID;
            //getting the current logged in user through the session that was set (Anderson, Larking & LaRose, 20225):
            report.userID = HttpContext.Session.GetString("uID");
            //creating a new document to upload to the database
            Document document = new Document();
            document.documentID = documentID;
            document.documentData = documentFile;

            




            

            return View();
        }
    }
}

//Refernece list:

//Anderson, R., Larkin, K. And LaRose, D. 2025. Session and state management in ASP.NET Core, 24 April 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0 [Accessed 6 September 2025].

//ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. 2022. Youtube video, added by Teddy Smith. [Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025]. 

//Geeksforgeeks. 2024. Different Types of HTML Helpers in ASP.NET MVC, 24 August 2022. [Online]. Avaliable at: https://www.geeksforgeeks.org/different-types-of-html-helpers-in-asp-net-mvc/ [Accessed 6 September 2025].


