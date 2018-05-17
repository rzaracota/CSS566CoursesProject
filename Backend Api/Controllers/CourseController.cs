using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Backend_Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    /// <summary>
    /// Course controller.
    /// </summary>
    [Produces("application/json")]
    [Route("course/")]
    public class CourseController : Controller
    {
        private ICourseRepository repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Backend_Api.Controllers.CourseController"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        public CourseController(ICourseRepository r)
        {
            this.repository = r;
        }

        // GET course/
        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public List<Course> Get()
        {
            return repository.GetAllCourses();
        }

        // GET course/5
        /// <summary>
        /// Get the course by course ID
        /// </summary>
        /// <returns>the course</returns>
        /// <param name="id">Identifier.</param>
        [HttpGet("{id}")]
        public Course Get(string id)
        {
            return repository.GetCourse(id);
        }


        //POST course/
        /// <summary>
        /// Add a new course
        /// </summary>
        /// <returns>void</returns>
        /// <param name="course">Course.</param>
        [HttpPost]
        public void Post([FromBody] Course course)
        {
            repository.CreateCourse(course);
        }



        // PUT course/5
        /// <summary>
        /// Modify a course
        /// </summary>
        /// <returns>void</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="course">Course.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course course)
        {
            repository.UpdateCourse(course);
        }

        // DELETE course/5
        /// <summary>
        /// Delete a course
        /// </summary>
        /// <returns>void</returns>
        /// <param name="id">Identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            repository.DeleteCourse(id);
        }
    }
}
