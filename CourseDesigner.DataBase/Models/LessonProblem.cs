namespace CourseDesigner.DataBase.Models
{
    public class LessonProblem
    {
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public Guid ProblemId { get; set; }
        public Problem Problem { get; set; }

    }
}
