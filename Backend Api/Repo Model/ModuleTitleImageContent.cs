using Backend_Api.Repo_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Repo_Model
{
    public class ModuleTitleImageContent : ModuleBaseContent 
    {
        /**
         * Constructs a new ModuleTitleImageContent.
         **/
        public ModuleTitleImageContent()
        {
            Type = "titleimage";
        }

        [JsonProperty(PropertyName = "Link")]
        public string Link { get; set; }
    }
}
