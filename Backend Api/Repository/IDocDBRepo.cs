using Backend_Api.Repo_Model;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository
{
public interface IDocDBRepo
{
    Task<Course> GetCourseAsync(string id);
    Task<Module> GetModuleAsync(string id);
    Task<List<Course>> GetAllCourseAsync();
    Task<List<Module>> GetAllModuleAsync();
    Task<Document> CreateCourseAsync(Course value);
    Task<Document> CreateModuleAsync(Module value);
    Task<Document> UpdateCourseAsync(string id, Course value);
    Task<Document> UpdateModuleAsync(string id, Module value);
    Task DeleteCourseAsync(string id);
    Task DeleteModuleAsync(string id);
    void Initialize();
}
}
