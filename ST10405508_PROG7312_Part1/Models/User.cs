using System.ComponentModel.DataAnnotations;

namespace ST10405508_PROG7312_Part1.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }

    }
}
