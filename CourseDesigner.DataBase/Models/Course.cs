using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDesigner.DataBase.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid? AuthorId { get; set; }

        public Author? Author { get; set; }

        public required string Name { get; set; }

        public required decimal Price { get; set; } = 0;

        public required string Description { get; set; } = "Отсутствует";

        public int CountSubscribers { get; set; } = 0;

        public List<User>? Subscribers { get; set; }

        public int CountLessons { get; set; } = 0;

        public List<Lesson>? Lessons { get; set; }

        public double Rating { get; set; }

        public required double Complexity { get; set; } = 0;
    }
}

