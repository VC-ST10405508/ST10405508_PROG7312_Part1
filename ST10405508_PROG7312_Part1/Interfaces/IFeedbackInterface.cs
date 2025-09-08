using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Interfaces
{
    public interface IFeedbackInterface
    {
        //interface that will deal with crud operations (Teddy Smith, 2022):
        Task<IEnumerable<Feedback>> GetAll();
        Task<List<Feedback>> GetUserFeedback(string userId);
        Task<Feedback> GetById(string id);

        Task<int> GetCount();
        bool Add(Feedback feedback);
        bool Delete(Feedback feedback);
        bool Update(Feedback feedback);
        bool Save();

    }
}
//Reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].