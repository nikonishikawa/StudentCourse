using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseClassLibrary.Dto
{
    public class StudentCourseDto
    {
        public long StudentCourseId { get; set; }

        public long StudentId { get; set; }

        public long CourseId { get; set; }

        public List<StudentDto> Students { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
