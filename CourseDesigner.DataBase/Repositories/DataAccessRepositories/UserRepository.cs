using CourseDesigner.DataBase.Models.DTOs;
using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;

namespace CourseDesigner.DataBase.Repositories.DataAccessRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> RegisterAuthor(Author author)
        {
            try
            {
                var existAuthor = await _context.Authors
                    .FirstOrDefaultAsync(u => u.Email == author.Email);

                if (existAuthor != null)
                {
                    return new ResultDto(new List<string> { "Ошибка БД: Email уже занят" });
                }

                await _context.Authors.AddAsync(author);

                await _context.SaveChangesAsync();

                return new ResultDto();
            }
            catch (Exception ex)
            {
                return new ResultDto(new List<string> { $"Произошла ошибка в БД: {ex}" });
            }
        }

        public async Task<ResultDto> RegisterUser(User user)
        {
            try
            {
                var existUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == user.Email);

                if (existUser != null)
                {
                    return new ResultDto(new List<string> { "Ошибка БД: Email уже занят" });
                }

                await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();

                return new ResultDto();
            }
            catch (Exception ex)
            {
                return new ResultDto(new List<string> { $"Произошла ошибка в БД: {ex}" });
            }
        }

    }
}
