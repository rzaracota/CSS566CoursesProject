using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Backend_Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    /// <summary>
    /// Module controller.
    /// </summary>
    [Produces("application/json")]
    [Route("module/")]
    public class ModuleController : Controller
    {
        private IModuleRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Backend_Api.Controllers.ModuleController"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        public ModuleController(IModuleRepository r)
        {
            this.repository = r;
        }

        // GET module/
        /// <summary>
        /// Get all modules
        /// </summary>
        /// <returns>A List of all modules</returns>
        [HttpGet]
        public List<Module> Get()
        {
            return repository.GetAllModules();
        }

        // GET module/5
        /// <summary>
        /// Get a module by module ID
        /// </summary>
        /// <returns>a module</returns>
        /// <param name="id">Identifier.</param>
        [HttpGet("{id}")]
        public Module Get(string id)
        {
            return repository.GetModule(id);
        }

        // POST module/
        /// <summary>
        /// Add a new module
        /// </summary>
        /// <returns>void</returns>
        /// <param name="module">Module.</param>
        [HttpPost]
        public void Post([FromBody] Module module)
        {
            repository.CreateModule(module);
        }

        // PUT module/5
        /// <summary>
        /// Modify a module by module ID
        /// </summary>
        /// <returns>void</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="module">Module.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Module module)
        {
            repository.UpdateModule(module);
        }

        // DELETE module/5
        /// <summary>
        /// Delete a module by module ID
        /// </summary>
        /// <returns>void</returns>
        /// <param name="id">Identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            repository.DeleteModule(id);
        }
    }
}
