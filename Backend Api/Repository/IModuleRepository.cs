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
        void CreateModule(Module module);
        void UpdateModule(Module module);
        Module GetModule(string id);
        List<Module> GetAllModules();
        void DeleteModule(string id);
    }
}
