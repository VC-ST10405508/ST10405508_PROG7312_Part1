using Microsoft.AspNetCore.Mvc;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;
using System.Net.Mime;
using System.Threading.Tasks;


namespace ST10405508_PROG7312_Part1.Controllers
{
    public class ReportIssueController : Controller
    {
        //read only fields for the data (Teddy Smith, 2022):
        private readonly IReportIssuesInterface _reportIssueInterface;
        private readonly IUserInterface _userInterface;
        private readonly IDocumentInterface _documentInterface;
        private readonly ILogger<ReportIssueController> _logger;
        public string errMsg = "";
        public string successMsg = "";
        //constructor of this controller (Teddy Smith, 2022):
        public ReportIssueController(IReportIssuesInterface reportIssueInterface, IUserInterface userInterface, IDocumentInterface documentInterface, ILogger<ReportIssueController> logger)
        {
            _reportIssueInterface = reportIssueInterface;
            _userInterface = userInterface;
            _documentInterface = documentInterface;
            _logger = logger;
        }
        public IActionResult AddReport()
        {
            return View();
        }
        public async Task<IActionResult> Reports()
        {
            //making sure the claimhistory returns the claims - update this to show specific lecturers claims, if you finish all other functionality (Teddy Smith, 2022):
            var reports = await _reportIssueInterface.GetAll();
            return View(reports);
        }

        //Add report function. Using an IFormFile to recieve the document (MicrosoftLearn, 2025):
        [HttpPost]
        public async Task<IActionResult> AddReport(ReportIssue report, IFormFile? documentFile)
        {
            //fethcing the users id from the current context (Anderson, Larkin & LaRose, 2025):
            if (HttpContext.Session.GetString("uID") == "" || HttpContext.Session.GetString("uID") == null)
            {
                ViewBag.ErrorMsg = "Must Sign in First!";
                return View();
            }
            //creating vars that will be used inside the view to display success or error (Geeksforgeeks, 2022):
            ViewBag.SuccessMsg = null;
            ViewBag.ErrorMsg = null;
            try
            {
                //setting report id for unique report
                var reportID = "R" + Guid.NewGuid().ToString("N");
                report.reportID = reportID;

                //getting the current logged in user through the session that was set (Anderson, Larking & LaRose, 2025):
                report.userID = HttpContext.Session.GetString("uID");
                //converting file to bytes if a file was uploaded (MicrosoftLearn, 2025):
                if (documentFile != null && documentFile.Length != 0)
                {
                    // setting ids to be unique for the database (MicrosoftLearn, 2025):
                    var documentID = "D" + Guid.NewGuid().ToString("N"); ;
                    report.documentID = documentID;
                    using var ms = new MemoryStream();
                    await documentFile.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    //creating a new document to upload to the database
                    Document document = new Document();
                    document.documentID = documentID;
                    document.documentData = fileBytes;
                    document.fileName = Path.GetFileName(documentFile.FileName);
                    document.contentType = documentFile.ContentType;

                    //trying to add document to db (Teddy Smith, 2022):
                    await _documentInterface.Add(document);
                }
                

                //document and report data should be complete by this point. 
                //making sure report data is not empty or null
                if (string.IsNullOrEmpty(report.reportID) || string.IsNullOrEmpty(report.reportName) || string.IsNullOrEmpty(report.location) || string.IsNullOrEmpty(report.status) || string.IsNullOrEmpty(report.userID) 
                    || string.IsNullOrEmpty(report.reportDescription) || string.IsNullOrEmpty(report.reportCategory) || string.IsNullOrEmpty(report.reportDate))
                {
                    ViewBag.ErrorMsg = "Please fill in all report details";
                    _logger.LogError("Report failed? report data: " + report.ToString());
                    return View();
                }
                
                // trying to save the report to the db (Teddy Smith, 2022):
                _reportIssueInterface.Add(report);

                ViewBag.SuccessMsg = "You have successfully reported the issue. We will look into your report ASAP. thank you for your patience :D";
                return View();
                


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = "Unexpected error: " + ex.Message;
                _logger.LogError("Error with adding report issue: " + ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> GetDocument(string documentId)
        {
            //making sure the file is not empty (Microsoftlearn, 2025):
            if (string.IsNullOrEmpty(documentId))
                return NotFound();
            //getting the document from the db (Teddy Smith, 2022):
            var document = await _documentInterface.GetById(documentId);
            if (document == null || document.documentData == null)
                return NotFound();
            
            var contentType = !string.IsNullOrEmpty(document.contentType)
                ? document.contentType
                : "application/octet-stream";

            var fileName = !string.IsNullOrEmpty(document.fileName)
                ? document.fileName
                : $"Document_{document.documentID}";
            //returning the file data (MicrosoftLearn, 2025):
            return File(document.documentData, contentType, fileName);
        }
    }
}

//Refernece list:

//Anderson, R., Larkin, K. And LaRose, D. 2025. Session and state management in ASP.NET Core, 24 April 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0 [Accessed 6 September 2025].

//Geeksforgeeks. 2024. Different Types of HTML Helpers in ASP.NET MVC, 24 August 2022. [Online]. Avaliable at: https://www.geeksforgeeks.org/different-types-of-html-helpers-in-asp-net-mvc/ [Accessed 6 September 2025].

//MicrosoftLearn. 2025. Upload files in ASP.NET Core, 9 August 2024. [Online]. Avaliable at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-8.0  [Accessed 8 September 2025].

//MicrosoftLearn. 2025. Guid.NewGuid Method. [Online]. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=net-9.0 [Accessed 8 September 2025].

//Teddy Smith, 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025]. 




