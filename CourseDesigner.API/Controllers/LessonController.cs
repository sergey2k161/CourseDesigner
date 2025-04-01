using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourseDesigner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromBody] LessonDto model)
        {
            await _lessonService.CreateLesson(model);

            return Ok();
        }

        [HttpPost("problemToLesson")]
        public async Task<IActionResult> AddProblemToLesson(Guid problemId, Guid lessonId)
        {
            await _lessonService.AddProblemToLesson(problemId, lessonId);

            return Ok();
        }
    }
}
