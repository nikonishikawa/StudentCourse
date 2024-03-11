using StudentCourseClassLibrary.APIResponse;
using StudentCourseClassLibrary.Dto;
using StudentCourseClassLibrary.Entities;

namespace StudentCourseClassLibrary.Services
{
    public interface IStudentCourseService
    {
        Task<ApiResponseMessage<string>> DeleteCourse(CourseDto dto);
        Task<ApiResponseMessage<string>> DeleteStudent(StudentDto dto);
        Task<ApiResponseMessage<IList<TblCourse>>> GetCourse(long courseId);
        Task<ApiResponseMessage<IList<TblStudent>>> GetStudent(long studentId);
        Task<ApiResponseMessage<string>> InsertCourse(CourseDto dto);
        Task<ApiResponseMessage<string>> InsertStudent(StudentDto dto);
        Task<ApiResponseMessage<string>> InsertStudentCourse(StudentCourseDto dto);
        Task<ApiResponseMessage<string>> InsertStudentCourseTemp(List<TblStudentCourseTemp> tempData);
    }
}