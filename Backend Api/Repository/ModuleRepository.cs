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

        public Module ConvertModuleApiToModule(ModuleApi api)
        {
            if (api == null)
            {
                return null;
            }
            Module dataModel = new Module();
            dataModel.Author = api.Author;
            dataModel.CourseIds = api.CourseIds;
            dataModel.Keywords = api.Keywords;
            dataModel.Layout = api.Layout;
            dataModel.Title = api.Title;
            dataModel.ModuleId = api.ModuleId;
            return dataModel;
        }

        public ModuleApi ConvertModuleToModuleApi(Module dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }
            ModuleApi api = new ModuleApi();
            api.Author = dataModel.Author;
            api.CourseIds = dataModel.CourseIds;
            api.Keywords = dataModel.Keywords;
            api.Layout = dataModel.Layout;
            api.Title = dataModel.Title;
            api.ModuleId = dataModel.ModuleId;
            return api;
        }

        public async Task CreateModule(ModuleApi module) {
            try
            {
                var result = await repo.CreateModuleAsync(
                    ConvertModuleApiToModule(module));
            } catch (Exception e)
            {

            }
        }

        public async Task DeleteModule(string id) {
            await repo.DeleteModuleAsync(id);
        }

        public List<ModuleApi> GetAllModules() {
            List<Module> dataModels = repo.GetAllModuleAsync().Result;
            List<ModuleApi> apis = new List<ModuleApi>();
            foreach (Module dataModel in dataModels)
            {
                apis.Add(ConvertModuleToModuleApi(dataModel));
            }
            return apis;
        }

        public ModuleApi GetModule(string id) {

            return ConvertModuleToModuleApi(repo.GetModuleAsync(id).Result); 
        }

        public async Task UpdateModule(ModuleApi api) {
            await repo.UpdateModuleAsync(
                api.ModuleId, 
                ConvertModuleApiToModule(api));
        }
    }
}
