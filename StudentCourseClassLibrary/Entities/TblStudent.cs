using System;
using System.Collections.Generic;

namespace StudentCourseClassLibrary.Entities;

public partial class TblStudent
{
    public long StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public virtual ICollection<TblStudentCourseTemp> TblStudentCourseTemps { get; set; } = new List<TblStudentCourseTemp>();

    public virtual ICollection<TblStudentCourse> TblStudentCourses { get; set; } = new List<TblStudentCourse>();
}
