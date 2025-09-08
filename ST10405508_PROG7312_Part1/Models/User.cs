using System.ComponentModel.DataAnnotations;

namespace ST10405508_PROG7312_Part1.Models
{
    public class User
    {
        //vars for user info with primary key inclusion for entity framework (see ASP.NET Core MVC 2022 - 2. Models, 2022):
        [Key]
        public string userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }

    }
}
//reference List:

//ASP.NET Core MVC 2022 - 2. Models. 2022. Youtube video, added by Teddy Smith. [Online]. Avaliable at: https://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmithhttps://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmith [Accessed 6 September 2025].
