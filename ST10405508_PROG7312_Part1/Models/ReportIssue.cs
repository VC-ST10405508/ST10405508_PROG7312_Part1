using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10405508_PROG7312_Part1.Models
{
    public class ReportIssue
    {
        //vars for report issue info with primary keys and foreign key inclusion (see ASP.NET Core MVC 2022 - 2. Models, 2022):
        [Key]
        public string reportID { get; set; }
        [Required]
        public string location { get; set; }
        public string reportName { get; set; }
        public string reportDescription { get; set; }
        public string reportDate { get; set; }
        public string reportCategory { get; set; }
        public string status { get; set; }

        [ForeignKey("Document")]
        public string? documentID { get; set; }

        [ForeignKey("User")]
        public string userID { get; set; }

    }
}
//reference List:

//ASP.NET Core MVC 2022 - 2. Models. 2022. Youtube video, added by Teddy Smith. [Online]. Avaliable at: https://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmithhttps://www.youtube.com/watch?v=p2kzp2d0a4A&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=2&ab_channel=TeddySmith [Accessed 6 September 2025].