using Backend_Api.Repo_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository {
    /**
     * Provides CRUD operations for the Module model.
     **/
    public interface IModuleRepository {
        Task CreateModule(Module module);
        Task UpdateModule(Module module);
        Task<Module> GetModule(string id);
        Task<List<Module>> GetAllModules();
        Task DeleteModule(string id);
    }
}
