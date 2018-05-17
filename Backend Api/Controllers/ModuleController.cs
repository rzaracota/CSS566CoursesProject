using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Backend_Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    [Produces("application/json")]
    [Route("module/")]
    public class ModuleController : Controller
    {
        private IModuleRepository repository;

        public ModuleController(IModuleRepository r)
        {
            this.repository = r;
        }

        // GET module/
        [HttpGet]
        public async Task<List<Module>> GetAsync()
        {
            return await repository.GetAllModules();
        }

        // GET module/5
        [HttpGet("{id}")]
        public async Task<Module> GetAsync(string id)
        {
            return await repository.GetModule(id);
        }

        // POST module/
        [HttpPost]
        public async Task PostAsync([FromBody] Module module)
        {
            await repository.CreateModule(module);
        }

        // PUT module/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Module module)
        {
            await repository.UpdateModule(module);
        }

        // DELETE module/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await repository.DeleteModule(id);
        }
    }
}
