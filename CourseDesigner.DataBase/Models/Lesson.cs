using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDesigner.DataBase.Models
{
    public class Lesson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required double Complexity { get; set; }

        public List<Problem>? Problems { get; set; }

        public Course Course { get; set; }

        public Guid CourseId { get; set; }
    }
}

