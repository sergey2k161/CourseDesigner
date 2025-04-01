using CourseDesigner.DataBase.Models;

namespace CourseDesigner.DataBase.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task CreateCourse(Course course);

        Task AddLessonToCourse(Guid lessonId, Guid courseId);
    }
}
