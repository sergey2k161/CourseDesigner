using System.ComponentModel.DataAnnotations;

namespace CourseDesigner.DataBase.Models.DTOs
{
    public class UserDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }  

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}