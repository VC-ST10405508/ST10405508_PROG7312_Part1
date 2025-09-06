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

        public bool Add(Document document)
        {
            _context.Add(document);
            return Save();
        }

        public bool Delete(Document document)
        {
            _context.Remove(document);
            return Save();
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _context.documents.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
