using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniCourses.Models;
using UniCourses.ViewModel;

namespace UniCourses.Repository
{
    public interface ICourseRepository
    {
        Task<List<University>> GetUniversities();

        Task<List<CourseViewModel>> GetCourses();

        Task<CourseViewModel> GetCourse(int? courseId);

        Task<int> AddCourse(Courses course);

        Task<int> DeleteCourse(int? courseId);

        Task<int> UpdateCourse(int? courseId);
    }
}
