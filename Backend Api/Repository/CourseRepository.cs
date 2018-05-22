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

        private CourseApi ConvertCourseToCourseApi(Course course)
        {
            CourseApi apiResult = new CourseApi();
            apiResult.CourseId = course.CourseId;
            apiResult.ModuleIds = course.ModuleIds;
            apiResult.Name = course.Name;
            return apiResult;
        }

        private Course ConvertCourseApiToCourse(CourseApi api)
        {
            Course dataModel = new Course();
            dataModel.CourseId = api.CourseId;
            dataModel.ModuleIds = api.ModuleIds;
            dataModel.Name = api.Name;
            return dataModel;
        }

        public async Task CreateCourse(CourseApi api) {
            // convert API to datamodel
            Course dataModel = ConvertCourseApiToCourse(api);
            try
            {
                var result = await repo.CreateCourseAsync(dataModel);
            } catch (Exception e)
            {

            }
        }

        public async Task DeleteCourseAsync(string id) {
            await repo.DeleteCourseAsync(id);
        }

        public List<CourseApi> GetAllCourses() {
            List<Course> dataModels =  repo.GetAllCourseAsync().Result;
            List<CourseApi> courseApis = new List<CourseApi>();

            foreach (Course dataModel in dataModels)
            {
                courseApis.Add(ConvertCourseToCourseApi(dataModel));
            }

            return courseApis;
        }

        public CourseApi GetCourse(string id) {
            return ConvertCourseToCourseApi(repo.GetCourseAsync(id).Result);
        }

        public async Task UpdateCourse(CourseApi api) {
            Course dataModel = ConvertCourseApiToCourse(api);
            await repo.UpdateCourseAsync(dataModel.CourseId, dataModel);
        }
    }
}
