using Microsoft.EntityFrameworkCore;
using ST10405508_PROG7312_Part1.Data;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Repository
{
    public class FeedbackRepository : IFeedbackInterface
    {
        private readonly AppDbContext _context;
        public FeedbackRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public bool Add(Feedback feedback)
        {
            _context.Add(feedback); 
            return Save();
        }

        public bool Delete(Feedback feedback)
        {
            _context.Remove(feedback);
            return Save();
        }
        //A custom method that will return the specific feedback (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
        public async Task<Feedback> GetByIdAsync(String id)
        {
            return await _context.feedbacks.FirstOrDefaultAsync(i => i.documentID == id);
        }

        public async Task<IEnumerable<Feedback>> GetAll()
        {
            return await _context.feedbacks.ToListAsync();
        }

        public bool Save()
        {
            //making sure all the data is saved to the database using entity framework (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
//Reference List:

//ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. 2022. Youtube video, added by Teddy Smith. [Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].