using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Models.DTOs;

namespace CourseDesigner.Business.Services.Interfaces
{
    public interface IUserService
    {
        string GenerateJwtToken(CommonUser user);
        Task<ResultDto> Login(LoginDto model);
        Task<ResultDto> RegisterUser(UserDto model);
        Task<ResultDto> RegisterAuthor(UserDto model);
    }
}