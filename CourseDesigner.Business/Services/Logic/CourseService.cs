using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Repositories.Interfaces;
using CourseDesigner.DataBase.Services.Interfaces;

namespace CourseDesigner.Business.Services.Logic
{
    internal class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task AddLessonToCourse(Guid lessonId, Guid courseId)
        {
            await _courseRepository.AddLessonToCourse(lessonId, courseId);
        }

        public async Task CreateCourse(CourseDto model)
        {
            var course = new Course
            {
                AuthorId = model.AuthorId,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Complexity = model.Complexity
            };

            await _courseRepository.CreateCourse(course);
        }
    }
}
