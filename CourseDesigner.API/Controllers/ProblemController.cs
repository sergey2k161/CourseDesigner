using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CourseDesigner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemController : ControllerBase
    {
        private readonly IProblemService _problemService;

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProblem(ProblemDto model)
        {
            await _problemService.CreateProblem(model);
            return Ok();
        }


        [HttpGet]
        public async Task<List<Problem>> GetProblems() 
        {
            return await _problemService.GetProblems();
        }
    }
}
