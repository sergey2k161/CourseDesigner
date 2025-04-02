using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Models.DTOs;
using CourseDesigner.DataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseDesigner.API.Controllers
{
    /// <summary>
    /// Контролер Auth
    /// </summary>
    [Controller]
    [Route("Api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Api регистрации пользователя
        /// </summary>
        /// <param name="user">Модель</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Данные равны null");
            }

            var result = await _userService.RegisterUser(user);

            if (!result.IsSuccess)
            {
                return BadRequest(new { result.Errors });
            }

            return Ok(result);
        }
        
        [HttpPost("register/Author")]
        public async Task<IActionResult> RegisterAuthor([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Данные равны null");
            }

            var result = await _userService.RegisterAuthor(user);

            if (!result.IsSuccess)
            {
                return BadRequest(new { result.Errors });
            }

            return Ok(result);
        }

        /// <summary>
        /// Api авторизации
        /// </summary>
        /// <param name="model">Модель авторизации</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (model == null)
            {
                return BadRequest("Данные равны null");
            }

            var result = await _userService.Login(model);

            if (!result.IsSuccess)
            {
                return BadRequest(new { result.Errors });
            }

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddHours(12)
            };

            if (result.Token == null)
            {
                return BadRequest("Ошибка токена");
            }

            Response.Cookies.Append("token", result.Token, cookieOptions);

            return Ok(result.Token);
        }
    }
}
