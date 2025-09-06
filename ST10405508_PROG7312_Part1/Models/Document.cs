using System.ComponentModel.DataAnnotations;

namespace ST10405508_PROG7312_Part1.Models
{
    public class Document
    {
        [Key]
        public string documentID { get; set; }
        public string documentName { get; set; }
        public string documentType { get; set; }

        public byte[] documentData { get; set; }


    }
}