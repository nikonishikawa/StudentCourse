using System;
using System.Collections.Generic;

namespace StudentCourseClassLibrary.Entities;

public partial class TblStudentCourse
{
    public long StudentCourseId { get; set; }

    public long StudentId { get; set; }

    public long CourseId { get; set; }

    public virtual TblCourse Course { get; set; } = null!;

    public virtual TblStudent Student { get; set; } = null!;
}
