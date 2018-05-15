using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Repository {
    public class CourseRepository : ICourseRepository {
        private AppDbContext context;
        private DbSet<Course> courses;

        /**
         * Constructs a CourseRepository.
         * 
         * @param context Database context manager.
         **/
        public CourseRepository(AppDbContext context) {
            this.context = context;
            courses = context.Set<Course>();
        }

        public void CreateCourse(Course course) {
            context.Entry(course).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteCourse(string id) {
            Course course = GetCourse(id);
            courses.Remove(course);
            context.SaveChanges();
        }

        public List<Course> GetAllCourses() {
            return courses.ToList();
        }

        public Course GetCourse(string id) {
            return courses.SingleOrDefault(c => c.CourseId == id);
        }

        public void UpdateCourse(Course course) {
            context.Entry(course).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
