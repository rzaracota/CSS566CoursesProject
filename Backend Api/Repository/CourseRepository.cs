using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Repository {
    public class CourseRepository : ICourseRepository {
        private IDocDBRepo repo;
        /**
         * Constructs a CourseRepository.
         * 
         * @param context Database context manager.
         **/
        public CourseRepository(IDocDBRepo repo) {
            this.repo = repo;
            this.repo.Initialize();
        }

        public async Task CreateCourse(Course course) {
            try
            {
                var result = await repo.CreateCourseAsync(course);
            } catch (Exception e)
            {

            }
        }

        public async Task DeleteCourseAsync(string id) {
            await repo.DeleteCourseAsync(id);
        }

        public async Task<List<Course>> GetAllCoursesAsync() {
            return await repo.GetAllCourseAsync();
        }

        public async Task<Course> GetCourse(string id) {
            return await repo.GetCourseAsync(id);
        }

        public async Task UpdateCourse(Course course) {
            await repo.UpdateCourseAsync(course.CourseId, course);
        }
    }
}
