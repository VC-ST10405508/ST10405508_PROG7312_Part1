using System.ComponentModel.DataAnnotations;

namespace ST10405508_PROG7312_Part1.Models
{
    public class Document
    {
        //vars for document info with primary key for entity framework (Teddy Smith, 2022):
        [Key]
        public string documentID { get; set; }
        public byte[] documentData { get; set; }


    }
}
//reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 2. Models. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmithhttps://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmith [Accessed 6 September 2025].