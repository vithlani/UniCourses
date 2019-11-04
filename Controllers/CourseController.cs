using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using UniCourses.Models;
using UniCourses.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniCourses.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {

        CourseRepository course = new CourseRepository();
        ICourseRepository courseRepository;
        public CourseController(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        [Route("GetUniversity")]
        public async Task<IActionResult> GetUniversity()
        {
            try
            {
                var universities = await courseRepository.GetUniversities();
                if (universities == null)
                {
                    return NotFound();
                }

                return Ok(universities);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                var courses = await courseRepository.GetCourses();
                if (courses == null)
                {
                    return NotFound();
                }

                return Ok(courses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("GetCourse")]
        public async Task<IActionResult> GetCourse(int? courseId)
        {
            if (courseId == null)
            {
                return BadRequest();
            }

            try
            {
                var course = await courseRepository.GetCourse(courseId);

                if (course == null)
                {
                    return NotFound();
                }

                return Ok(course);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddCourse([FromBody]Courses model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var courseId = await course.AddCourse(model);
                    if (courseId > 0)
                    {
                        return Ok(courseId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
        [HttpPost]
        [Route("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(int? courseId)
        {
            int result = 0;

            if (courseId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await course.DeleteCourse(courseId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(int? courseId)
        {
            int result = 0;

            if (courseId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await course.UpdateCourse(courseId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

    }
}

