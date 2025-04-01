using CourseDesigner.DataBase.Models;

namespace CourseDesigner.DataBase.Repositories.Interfaces
{
    public interface ILessonRepository
    {
        Task CreateLesson(Lesson lesson);

        Task AddProblemToLesson(Guid problemId, Guid lessonId);
    }
}
