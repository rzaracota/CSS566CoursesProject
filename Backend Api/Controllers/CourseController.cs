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
        public async Task<List<Course>> GetAsync()
        {
            return await repository.GetAllCoursesAsync();
        }

        // GET course/5
        [HttpGet("{id}")]
        public async Task<Course> GetAsync(string id)
        {
            return await repository.GetCourse(id);
        }

        //POST course/
        [HttpPost]
        public async Task PostAsync([FromBody] Course course)
        {
            await repository.CreateCourse(course);
        }

        //[HttpPost]
        //public void Post()
        //{
        //    string documentContents;
        //    using (Stream receiveStream = Request.Body )
        //    {
        //        using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
        //        {
        //            documentContents = readStream.ReadToEnd();
        //        }
        //    }
        //    System.Diagnostics.Debug.Write(documentContents);
        //}

        // PUT course/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Course course)
        {
            await repository.UpdateCourse(course);
        }

        // DELETE course/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await repository.DeleteCourseAsync(id);
        }
    }
}
