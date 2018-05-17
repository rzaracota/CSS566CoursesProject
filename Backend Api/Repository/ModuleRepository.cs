using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend_Api.Repository {
    public class ModuleRepository : IModuleRepository {
        private IDocDBRepo repo;
        //private List<Module> modules;

        /**
         * Constructs a ModuleRepository.
         * 
         * @param context Database context manager.
         **/
        public ModuleRepository(IDocDBRepo repo) {
            this.repo = repo;
            this.repo.Initialize();
        }

        public async Task CreateModule(Module module) {
            try
            {
                var result = await repo.CreateModuleAsync(module);
            } catch (Exception e)
            {

            }
        }

        public async Task DeleteModule(string id) {
            await repo.DeleteModuleAsync(id);
        }

        public async Task<List<Module>> GetAllModules() {
            return await repo.GetAllModuleAsync();
        }

        public async Task<Module> GetModule(string id) {

            return await repo.GetModuleAsync(id); 
        }

        public async Task UpdateModule(Module module) {
            await repo.UpdateModuleAsync(module.ModuleId, module);
        }
    }
}
