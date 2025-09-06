using Microsoft.EntityFrameworkCore;
using ST10405508_PROG7312_Part1.Data;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;
using System.Threading.Tasks;

namespace ST10405508_PROG7312_Part1.Repository
{
    public class ReportIssueRepository : IReportIssuesInterface
    {
        private readonly AppDbContext _appDbContext;

        public ReportIssueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //predefined SQL Entityframework CRUD operations that return to the save method int his class (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
        public bool Add(ReportIssue issue)
        {
            _appDbContext.Add(issue);
            return Save();
        }

        public async Task<IEnumerable<ReportIssue>> GetAll()
        {
            return await _appDbContext.reportIssues.ToListAsync();
        }
        //A custom method that will return the specific report issue (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
        public async Task<ReportIssue> GetReportIssueByIdAsync(string id)
        {
            return await _appDbContext.reportIssues.FirstOrDefaultAsync(i => i.reportID == id);
        }

        public bool Remove(ReportIssue issue)
        {
            _appDbContext.Remove(issue);
           return Save();
        }

        public bool Save()
        {
            //making sure all the data is saved to the database using entity framework (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ReportIssue issue)
        {
            _appDbContext.Update(issue);
            return Save();
        }
    }
}
//Reference List:

//ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. 2022. Youtube video, added by Teddy Smith. [Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].