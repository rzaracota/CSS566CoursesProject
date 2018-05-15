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
        private AppDbContext context;
        //private DbSet<Module> modules;
        private List<Module> modules;

        /**
         * Constructs a ModuleRepository.
         * 
         * @param context Database context manager.
         **/
        public ModuleRepository(AppDbContext context) {
            this.context = context;
            modules = new List<Module>();
        }

        public void CreateModule(Module module) {
            // TODO: write to file
            List<Module> modules = new List<Module>();

            // read from a file
            using (StreamReader sr = new StreamReader("C:\\Users\\mitchell.t.lee\\Desktop\\modules.txt"))
            {
                List<Module> readModules = JsonConvert.DeserializeObject<List<Module>>(sr.ReadToEnd());

                if (readModules != null) {
                    modules = readModules;
                }
            }

            modules.Add(module);

            // write out to a file
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamWriter sw = new StreamWriter("C:\\Users\\mitchell.t.lee\\Desktop\\modules.txt"))
                {

                    sw.WriteLine(JsonConvert.SerializeObject(modules));
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteModule(string id) {
            Module module = GetModule(id);
            modules.Remove(module);
            context.SaveChanges();
        }

        public List<Module> GetAllModules() {
            List<Module> modules = new List<Module>();

            // read from a file
            using (StreamReader sr = new StreamReader("C:\\Users\\mitchell.t.lee\\Desktop\\modules.txt"))
            {
                List<Module> readModules = JsonConvert.DeserializeObject<List<Module>>(sr.ReadToEnd());

                if (readModules != null)
                {
                    modules = readModules;
                }
            }

            return modules;
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
