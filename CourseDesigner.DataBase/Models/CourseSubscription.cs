using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDesigner.DataBase.Models
{
    public class CourseSubscription
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }

}
