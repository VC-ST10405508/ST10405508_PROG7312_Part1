using Microsoft.EntityFrameworkCore;
using ST10405508_PROG7312_Part1.Data;
using ST10405508_PROG7312_Part1.Models;
using ST10405508_PROG7312_Part1.Interfaces;

namespace ST10405508_PROG7312_Part1.Repository
{
    public class DocumentRepository : IDocumentInterface
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }
        //CRUD operations with entity framework and some custom functions (Teddy Smith, 2022):
        public async Task<bool> Add(Document document)
        {
            _context.Add(document);
            return Save();
        }
        public async Task<int> GetCount()
        {
            return await _context.documents.CountAsync();
        }

        public bool Delete(Document document)
        {
            _context.Remove(document);
            return Save();
        }
        //A custom method that will return the specific document (Teddy Smith, 2022):
        public async Task<Document> GetById(string id)
        {
            return await _context.documents.FirstOrDefaultAsync(i => i.documentID == id);
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _context.documents.ToListAsync();
        }

        public bool Save()
        {
            //making sure all the data is saved to the database using entity framework (Teddy Smith, 2022):
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
//Reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].