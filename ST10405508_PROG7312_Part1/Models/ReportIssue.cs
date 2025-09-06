using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10405508_PROG7312_Part1.Models
{
    public class ReportIssue
    {
        [Key]
        public int reportID { get; set; }
        [Required]
        public string reportName { get; set; }
        public string reportDescription { get; set; }
        public string reportDate { get; set; }

        [ForeignKey("Document")]
        public string documentID { get; set; }

        [ForeignKey("User")]
        public string userID { get; set; }

    }
}
