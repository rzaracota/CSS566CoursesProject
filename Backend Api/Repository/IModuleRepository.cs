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
        Task CreateModule(ModuleApi module);
        Task UpdateModule(ModuleApi module);
        ModuleApi GetModule(string id);
        List<ModuleApi> GetAllModules();
        Task DeleteModule(string id);
    }
}
