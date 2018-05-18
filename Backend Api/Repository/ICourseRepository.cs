using Backend_Api.Repo_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository {
    /**
     * Provides CRUD operations for the Course model.
     **/
    public interface ICourseRepository {
        Task CreateCourse(Course course);
        Task UpdateCourse(Course course);
        Task<Course> GetCourse(string id);
        Task<List<Course>> GetAllCoursesAsync();
        Task DeleteCourseAsync(string id);
    }
}
