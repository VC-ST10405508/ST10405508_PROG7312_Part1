using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10405508_PROG7312_Part1.Models
{
    public class Feedback
    {
        //vars for user info with primary + foreign key inclusion for entity framework (see ASP.NET Core MVC 2022 - 2. Models, 2022):
        [Key]
        public string feedbackID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string date {  get; set; }
        [ForeignKey("User")]
        public string userID { get; set; }
        [ForeignKey("Document")]
        public string? documentID { get; set; }

    
    }
}
//reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 2. Models. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmithhttps://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmith [Accessed 6 September 2025].