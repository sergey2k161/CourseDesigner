using Microsoft.AspNetCore.Identity;

namespace CourseDesigner.DataBase.Models
{
    public class CommonUser : IdentityUser<Guid>
    {
        public Author? Author { get; set; }
        public Guid? AuthorId { get; set; }

        public User? User { get; set; }
        public Guid? UserId { get; set; }
    }
}
