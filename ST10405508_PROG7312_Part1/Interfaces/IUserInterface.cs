using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Interfaces
{
    public interface IUserInterface
    {

        //creating an interface to perform crud operations for user (Teddy Smith, 2022):
        Task<IEnumerable<User>> GetAll();
        Task<int> GetCount();
        Task<User> Login(string username);
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();

    }
}
//Reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].