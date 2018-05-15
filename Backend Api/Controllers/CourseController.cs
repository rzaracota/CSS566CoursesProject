using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Backend_Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    [Produces("application/json")]
    [Route("course/")]
    public class CourseController : Controller
    {
        private ICourseRepository repository;

        public CourseController(ICourseRepository r)
        {
            this.repository = r;
        }

        // GET course/
        [HttpGet]
        public List<Course> Get()
        {
            return repository.GetAllCourses();
        }

        // GET course/5
        [HttpGet("{id}")]
        public Course Get(string id)
        {
            return repository.GetCourse(id);
        }

        // POST course/
        [HttpPost]
        public void Post([FromBody] Course course)
        {
            repository.CreateCourse(course);
        }

        // PUT course/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course course)
        {
            repository.UpdateCourse(course);
        }

        // DELETE course/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            repository.DeleteCourse(id);
        }
    }
}
