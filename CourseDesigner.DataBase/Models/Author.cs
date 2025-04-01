using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDesigner.DataBase.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CommonUserId { get; set; }
        public CommonUser CommonUser { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }


        public List<Course>? Courses { get; set; }
    }
}

