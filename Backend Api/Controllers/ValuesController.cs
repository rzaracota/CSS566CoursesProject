using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Api.Repo_Model;
using Backend_Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IModuleRepository moduleRepository;

        public ValuesController(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Module>> GetAsync()
        {
            return await moduleRepository.GetAllModules();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Module> GetAsync(string id)
        {
            return await moduleRepository.GetModule(id);
        }

        // POST api/values
        [HttpPost]
        public async Task PostAsync([FromBody] Module module)
        {
            await moduleRepository.CreateModule(module);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Module module)
        {
            await moduleRepository.UpdateModule(module);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await moduleRepository.DeleteModule(id);
        }
    }
}
