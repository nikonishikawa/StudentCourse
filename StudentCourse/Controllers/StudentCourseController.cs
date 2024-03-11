using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseClassLibrary.APIResponse;
using StudentCourseClassLibrary.Dto;
using StudentCourseClassLibrary.Entities;
using StudentCourseClassLibrary.Services;

namespace StudentCourse.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _StudentCourseService;

        public StudentCourseController(IStudentCourseService StudentCourseService)
        {
            _StudentCourseService = StudentCourseService;
        }

        [HttpPost("InsertStudentCourseTemp")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertStudentCourseTemp(List<TblStudentCourseTemp> tempData)
        {
            try
            {
                var res = await _StudentCourseService.InsertStudentCourseTemp(tempData);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertStudentCourseTemp: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPost("InsertStudentCourse")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertStudentCourse(StudentCourseDto dto)
        {
            try
            {
                var res = await _StudentCourseService.InsertStudentCourse(dto);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertName: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPost("InsertStudent")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertStudent(StudentDto dto)
        {
            try
            {
                var res = await _StudentCourseService.InsertStudent(dto);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertName: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpGet("GetStudent/{StudentId}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblStudent>>>> GetStudent(long StudentId)
        {
            try
            {
                var res = await _StudentCourseService.GetStudent(StudentId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblStudent>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpDelete("DeleteStudent")]
        public async Task<ApiResponseMessage<string>> DeleteStudent(StudentDto dto)
        {
            try
            {
                var res = await _StudentCourseService.DeleteStudent(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPost("InsertCourse")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCourse(CourseDto dto)
        {
            try
            {
                var res = await _StudentCourseService.InsertCourse(dto);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertName: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpGet("GetCourse/{CourseId}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblCourse>>>> GetCourse(long CourseId)
        {
            try
            {
                var res = await _StudentCourseService.GetCourse(CourseId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCourse>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpDelete("DeleteCourse")]
        public async Task<ApiResponseMessage<string>> DeleteCourse(CourseDto dto)
        {
            try
            {
                var res = await _StudentCourseService.DeleteCourse(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
    }
}
