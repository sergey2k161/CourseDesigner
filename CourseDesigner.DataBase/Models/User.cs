using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDesigner.DataBase.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CommonUserId { get; set; }
        public CommonUser CommonUser { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public required string Name { get; set; }

        public List<Course>? Courses { get; set; }
    }
}