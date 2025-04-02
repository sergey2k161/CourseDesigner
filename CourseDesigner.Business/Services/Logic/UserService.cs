using CourseDesigner.DataBase.Models.DTOs;
using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using CourseDesigner.Business.Services.Interfaces;

namespace CourseDesigner.Business.Services.Logic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<CommonUser> _userManager;
        private readonly SignInManager<CommonUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, UserManager<CommonUser> userManager, SignInManager<CommonUser> signInManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user">Модель пользоваетля</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<ResultDto> RegisterUser(UserDto model)
        {
            try
            {
                var commonUser = new CommonUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var createUser = await _userManager.CreateAsync(commonUser, model.Password);

                if (!createUser.Succeeded)
                {
                    return new ResultDto(createUser.Errors.Select(e => e.Description).ToList());
                }

                var user = new User
                {
                    CommonUserId = commonUser.Id,
                    Name = model.Name,
                    Email = model.Email
                };

                var registerUser = await _userRepository.RegisterUser(user);

                if (!registerUser.IsSuccess)
                {
                    return new ResultDto(registerUser.Errors);
                }

                commonUser.UserId = user.Id;
                await _userManager.UpdateAsync(commonUser);

                return new ResultDto();
            }
            catch (Exception ex)
            {
                return new ResultDto(new List<string> { $"Обнаружена ошибка {ex}" });
            }

        }

        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="model">Модель авторизации</param>
        /// <returns></returns>
        public async Task<ResultDto> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new ResultDto(new List<string> { "Пользователь не найден" });
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: true);

            var token = GenerateJwtToken(user);

            if (result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Token = token
                };
            }

            return new ResultDto(new List<string> { "Ошибка авторизации" });
        }

        /// <summary>
        /// Генерация JWT токена
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public string GenerateJwtToken(CommonUser user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ResultDto> RegisterAuthor(UserDto model)
        {
            try
            {
                var commonUser = new CommonUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var createUser = await _userManager.CreateAsync(commonUser, model.Password);

                if (!createUser.Succeeded)
                {
                    return new ResultDto(createUser.Errors.Select(e => e.Description).ToList());
                }

                var author = new Author
                {
                    CommonUserId = commonUser.Id,
                    Name = model.Name,
                    Email = model.Email
                };

                var registerUser = await _userRepository.RegisterAuthor(author);

                if (!registerUser.IsSuccess)
                {
                    return new ResultDto(registerUser.Errors);
                }

                commonUser.AuthorId = author.Id;
                await _userManager.UpdateAsync(commonUser);

                return new ResultDto();
            }
            catch (Exception ex)
            {
                return new ResultDto(new List<string> { $"Обнаружена ошибка {ex}" });
            }
        }
    }
}
