using CourseDesigner.DataBase.Services.Interfaces;

namespace CourseDesigner.Business.Services.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(CourseDto model);

        Task AddLessonToCourse(Guid lessonId, Guid courseId);
    }
}
