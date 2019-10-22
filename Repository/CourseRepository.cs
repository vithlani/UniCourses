using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniCourses.Models;
using UniCourses.ViewModel;

namespace UniCourses.Repository
{
    public class CourseRepository : ICourseRepository
    {
        CRUDContext db;

        public CourseRepository()
        {
        }

        public CourseRepository(CRUDContext _db)
        {
            db = _db;
        }
        public async Task<int> AddCourse(Courses course)
        {
            if (db != null)
            {
                await db.Courses.AddAsync(course);
                await db.SaveChangesAsync();

                return course.CId;
            }

            return 0;
        }

        public async Task<int> DeleteCourse(int? courseId)
        {
            int result = 0;

            if (db != null)
            {
                var course = await db.Courses.FirstOrDefaultAsync(x => x.CId == courseId);

                if (course != null)
                {
                    db.Courses.Remove(course);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<CourseViewModel> GetCourse(int? courseId)
        {
            if (db != null)
            {
                return await(from p in db.Courses
                             from c in db.University
                             where p.CId == courseId
                             select new CourseViewModel
                             {
                                 CId = p.CId,
                                 CName = p.CName,
                                 CDuration = p.CDuration,
                                 Description = p.Description,
                                 UniversityId = p.UniversityId,
                                 Name = c.Name,
                                 CreatedDate = p.CreatedDate
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<CourseViewModel>> GetCourses()
        {
            if (db != null)
            {
                return await (from p in db.Courses
                              from c in db.University
                              where p.CId == c.Id
                              select new CourseViewModel
                              {
                                  CId = p.CId,
                                  CName = p.CName,
                                  CDuration = p.CDuration,
                                  Description = p.Description,
                                  UniversityId = p.UniversityId,
                                  Name = c.Name,
                                  CreatedDate = p.CreatedDate
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<List<University>> GetUniversities()
        {
            if (db != null)
            {
                return await db.University.ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateCourse(int? courseId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific course id
                var course = await db.Courses.FirstOrDefaultAsync(x => x.CId == courseId);

                if (course != null)
                {
                    //Update that course
                    db.Courses.Update(course);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        internal Task UpdateCourse(Courses model)
        {
            throw new NotImplementedException();
        }
    }
}
