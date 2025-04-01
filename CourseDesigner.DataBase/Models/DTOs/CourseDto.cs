namespace CourseDesigner.DataBase.Services.Interfaces
{
    public class CourseDto
    {
        public Guid? AuthorId { get; set; }

        public required string Name { get; set; }

        public required decimal Price { get; set; } = 0;

        public required string Description { get; set; } = "Отсутствует";

        public required double Complexity { get; set; } = 0;
    }
}