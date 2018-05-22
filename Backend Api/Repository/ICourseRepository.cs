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
        Task CreateCourse(CourseApi course);
        Task UpdateCourse(CourseApi course);
        CourseApi GetCourse(string id);
        List<CourseApi> GetAllCourses();
        Task DeleteCourseAsync(string id);
    }
}
