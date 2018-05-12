using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Repository {
    public class ModuleRepository : IModuleRepository {
        private AppDbContext context;
        private DbSet<Module> modules;

        /**
         * Constructs a ModuleRepository.
         * 
         * @param context Database context manager.
         **/
        public ModuleRepository(AppDbContext context) {
            this.context = context;
            modules = context.Set<Module>();
        }

        public void CreateModule(Module module) {
            context.Entry(module).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteModule(string id) {
            Module module = GetModule(id);
            modules.Remove(module);
            context.SaveChanges();
        }

        public IEnumerable<Module> GetAllModules() {
            return modules.AsEnumerable();
        }

        public Module GetModule(string id) {
            return modules.SingleOrDefault(m => m.Id == id);
        }

        public void UpdateModule(Module module) {
            context.Entry(module).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
