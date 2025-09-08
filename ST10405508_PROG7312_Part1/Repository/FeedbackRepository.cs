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
        // Crud operations through entity framework (Teddy Smith, 2022):
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
        //A custom method that will return the specific feedback (Teddy Smith, 2022):
        public async Task<Feedback> GetById(string id)
        {
            return await _context.feedbacks.FirstOrDefaultAsync(i => i.documentID == id);
        }
        public async Task<int> GetCount()
        {
            return await _context.feedbacks.CountAsync();
        }

        public async Task<IEnumerable<Feedback>> GetAll()
        {
            return await _context.feedbacks.ToListAsync();
        }

        public bool Save()
        {
            //making sure all the data is saved to the database using entity framework (Teddy Smith, 2022):
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Feedback feedback)
        {
            //will be updated in future parts potentially
            throw new NotImplementedException();
        }

        public async Task<List<Feedback>> GetUserFeedback(string userId)
        {
            return await _context.feedbacks.Where(f => f.userID == userId).ToListAsync();
        }
    }
}
//Reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].