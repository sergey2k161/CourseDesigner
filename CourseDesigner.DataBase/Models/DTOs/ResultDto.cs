using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDesigner.DataBase.Models.DTOs
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }
        public string? Token { get; set; }
        public CommonUser User { get; set; }

        /// <summary>
        /// Ответ на ошибку
        /// </summary>
        /// <param name="errors">Список ошибок</param>
        public ResultDto(List<string> errors)
        {
            IsSuccess = false;
            Errors = errors;
        }

        /// <summary>
        /// Ответ об успешном выполнении
        /// </summary>
        public ResultDto()
        {
            IsSuccess = true;
        }
    }
}
