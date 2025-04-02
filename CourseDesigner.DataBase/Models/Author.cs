using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDesigner.DataBase.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CommonUserId { get; set; }
        public CommonUser CommonUser { get; set; }

        public string Name { get; set; }

        //public Guid UserId { get; set; }
        //public User User { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Course>? Courses { get; set; }
    }
}

