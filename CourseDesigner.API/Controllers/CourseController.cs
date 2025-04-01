using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseDesigner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto model)
        {
            await _courseService.CreateCourse(model);

            return Ok();
        }


        // ГАЛЯ У НАС ОТМЕНА, РАЗРАБОТЧИК ДУРАК
        //[HttpPost("lessonToCourse")]
        //public async Task<IActionResult> AddLessonToCourse(Guid lessonId, Guid courseId)
        //{
        //    await _courseService.AddLessonToCourse(lessonId, courseId);

        //    return Ok();
        //}
    }
}
