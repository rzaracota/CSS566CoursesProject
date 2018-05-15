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
        public List<Module> Get()
        {
            return moduleRepository.GetAllModules();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Module Get(string id)
        {
            return moduleRepository.GetModule(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Module module)
        {
            moduleRepository.CreateModule(module);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Module module)
        {
            moduleRepository.UpdateModule(module);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            moduleRepository.DeleteModule(id);
        }
    }
}
