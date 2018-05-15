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
        public List<Module> Get()
        {
            return repository.GetAllModules();
        }

        // GET module/5
        [HttpGet("{id}")]
        public Module Get(string id)
        {
            return repository.GetModule(id);
        }

        // POST module/
        [HttpPost]
        public void Post([FromBody] Module module)
        {
            repository.CreateModule(module);
        }

        // PUT module/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Module module)
        {
            repository.UpdateModule(module);
        }

        // DELETE module/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            repository.DeleteModule(id);
        }
    }
}
