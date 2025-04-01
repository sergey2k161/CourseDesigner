using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDesigner.DataBase.Models.DTOs
{
    public class LessonDto
    {
        public required string Name { get; set; }

        public required double Complexity { get; set; }

        // public List<Problem>? Problems { get; set; }

        public Guid CourseId { get; set; }
    }
}
