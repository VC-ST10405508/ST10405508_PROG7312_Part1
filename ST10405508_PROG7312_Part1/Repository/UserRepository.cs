using Microsoft.EntityFrameworkCore;
using ST10405508_PROG7312_Part1.Data;
using ST10405508_PROG7312_Part1.Interfaces;
using ST10405508_PROG7312_Part1.Models;
using System.Runtime.CompilerServices;

namespace ST10405508_PROG7312_Part1.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //predefined SQL Entityframework CRUD operations that return to the save method int his class (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
        public bool Add(User user)
        {
            _appDbContext.Add(user);
            return Save();
        }
        public async Task<User> Login(string username)
        {
            return await _appDbContext.users.FirstOrDefaultAsync(u => u.username == username || u.email == username);
        }
        public async Task<int> GetCount()
        {
            return await _appDbContext.users.CountAsync();
        }

        public bool Delete(User user)
        {
            _appDbContext.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appDbContext.users.ToListAsync();
        }

        public bool Save()
        {
            //making sure all the data is saved to the database using entity framework (see ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern, 2022):
            var saved = _appDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _appDbContext.Update(user);
            return Save();
        }
    }
}
//Reference List:

//ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. 2022. Youtube video, added by Teddy Smith. [Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].