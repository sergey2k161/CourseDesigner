using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Models.DTOs;
using CourseDesigner.DataBase.Repositories.Interfaces;

namespace CourseDesigner.Business.Services.Logic
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task AddProblemToLesson(Guid problemId, Guid LessonId)
        {
            await _lessonRepository.AddProblemToLesson(problemId, LessonId);
        }

        public async Task CreateLesson(LessonDto model)
        {
            var lesson = new Lesson
            {
                Name = model.Name,
                Complexity = model.Complexity,
                //Problems = model.Problems,
                CourseId = model.CourseId,
            };

            await _lessonRepository.CreateLesson(lesson);
        }
    }
}
