using Backend_Api.Repo_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository {
    public interface IModuleRepository {
        void CreateModule(Module module);
        void UpdateModule(Module module);
        void GetModule(string id);
        void DeleteModule(string id);
    }
}
