using ST10405508_PROG7312_Part1.Models;

namespace ST10405508_PROG7312_Part1.Interfaces
{
    public interface IDocumentInterface
    {
        //interface that will deal with crud operations (Teddy Smith, 2022):
        Task<IEnumerable<Document>> GetAll();

        Task<int> GetCount();

        Task<Document> GetById(string id);
        bool Add(Document document);
        bool Delete(Document document);
        bool Save();

    }

    //Reference List:

    //Teddy Smith. 2022. ASP.NET Core MVC 2022 - 7. Dependency Injection + Repository Pattern. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=o3258sYHhng&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=8&ab_channel=TeddySmith [Accessed 6 September 2025].
}

