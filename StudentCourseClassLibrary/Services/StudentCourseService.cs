using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StudentCourseClassLibrary.APIResponse;
using StudentCourseClassLibrary.Dto;
using StudentCourseClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseClassLibrary.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly StudentCourseDbContext _dbContext;
        public StudentCourseService(StudentCourseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertStudent(StudentDto dto)
        {
            try
            {
                var _insertStudent = new TblStudent
                {
                    StudentId = dto.StudentId,
                    StudentName = dto.StudentName
                };

                await _dbContext.TblStudents.AddAsync(_insertStudent);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Successfully added",
                    IsSuccess = true,
                    Message = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<IList<TblStudent>>> GetStudent(long studentId)
        {
            try
            {
                var _data = await _dbContext.TblStudents
                    .Where(x => x.StudentId == studentId)
                    .Select(x => new TblStudent
                    {
                        StudentId = x.StudentId,
                        StudentName = x.StudentName
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblStudent>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblStudent>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> DeleteStudent(StudentDto dto)
        {
            try
            {
                var UserToDelete = await _dbContext.TblStudents.FirstOrDefaultAsync(x => x.StudentId == dto.StudentId);

                if (UserToDelete != null)
                {

                    UserToDelete.StudentId = dto.StudentId;
                    UserToDelete.StudentName = dto.StudentName;

                    _dbContext.TblStudents.Remove(UserToDelete);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Deleted Successfully madafaka",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"User with ID {dto.StudentId} not found"
                    };

                    return res;
                }
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

        public async Task<ApiResponseMessage<string>> InsertCourse(CourseDto dto)
        {
            try
            {
                var _insertCourse = new TblCourse
                {
                    CourseId = dto.CourseId,
                    Course = dto.Course
                };

                await _dbContext.TblCourses.AddAsync(_insertCourse);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Successfully added",
                    IsSuccess = true,
                    Message = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<IList<TblCourse>>> GetCourse(long courseId)
        {
            try
            {
                var _data = await _dbContext.TblCourses
                    .Where(x => x.CourseId == courseId)
                    .Select(x => new TblCourse
                    {
                        CourseId = x.CourseId,
                        Course = x.Course
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblCourse>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCourse>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> DeleteCourse(CourseDto dto)
        {
            try
            {
                var UserToDelete = await _dbContext.TblCourses.FirstOrDefaultAsync(x => x.CourseId == dto.CourseId);

                if (UserToDelete != null)
                {

                    UserToDelete.CourseId = dto.CourseId;
                    UserToDelete.Course = dto.Course;

                    _dbContext.TblCourses.Remove(UserToDelete);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Deleted Successfully madafaka",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"User with ID {dto.CourseId} not found"
                    };

                    return res;
                }
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

        public async Task<ApiResponseMessage<string>> InsertStudentCourse(StudentCourseDto dto)
        {
            try
            {
                foreach (var studentDto in dto.Students)
                {
                    var student = new TblStudent
                    {
                        StudentName = studentDto.StudentName
                        // Add other student properties as needed
                    };

                    await _dbContext.TblStudents.AddAsync(student);
                }

                await _dbContext.SaveChangesAsync(); // Save changes to insert students

                foreach (var studentDto in dto.Students)
                {
                    var student = await _dbContext.TblStudents.SingleAsync(s => s.StudentName == studentDto.StudentName);

                    foreach (var courseDto in dto.Courses)
                    {
                        var course = new TblCourse
                        {
                            Course = courseDto.Course
                            // Add other course properties as needed
                        };

                        await _dbContext.TblCourses.AddAsync(course);
                    }

                    await _dbContext.SaveChangesAsync(); // Save changes to insert courses

                    foreach (var courseDto in dto.Courses)
                    {
                        var course = await _dbContext.TblCourses.SingleAsync(c => c.Course == courseDto.Course);

                        var studentCourse = new TblStudentCourse
                        {
                            Student = student,
                            Course = course
                        };

                        await _dbContext.TblStudentCourses.AddAsync(studentCourse);
                    }
                }

                await _dbContext.SaveChangesAsync(); // Save changes to create student-course relationships

                var response = new ApiResponseMessage<string>
                {
                    Data = "Successfully added",
                    IsSuccess = true,
                    Message = ""
                };

                return response;
            }
            catch (Exception ex)
            {
                var response = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = $"An error occurred while saving changes. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}",
                };

                return response;
            }
        }

        public async Task<ApiResponseMessage<string>> InsertStudentCourseTemp(List<TblStudentCourseTemp> tempData)
        {
            try
            {
                foreach (var temp in tempData)
                {
                    var student = new TblStudent
                    {
                        StudentId = temp.StudentId,
                        // Add other student properties as needed
                    };

                    var course = new TblCourse
                    {
                        CourseId = temp.CourseId,
                        // Add other course properties as needed
                    };

                    var studentCourse = new TblStudentCourseTemp
                    {
                        Student = student,
                        Course = course,
                    };

                    await _dbContext.TblStudentCourseTemps.AddAsync(studentCourse);
                }

                await _dbContext.SaveChangesAsync(); // Save changes to insert data into TblStudentCoursesTemp

                var response = new ApiResponseMessage<string>
                {
                    Data = "Successfully added",
                    IsSuccess = true,
                    Message = "",
                };

                return response;
            }
            catch (Exception ex)
            {
                var response = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = $"An error occurred. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}",
                };

                return response;
            }
        }


    }
}
