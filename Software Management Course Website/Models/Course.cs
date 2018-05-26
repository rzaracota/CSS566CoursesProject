using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Software_Management_Course_Website.Models
{
    public class Course
    {
        [JsonProperty(PropertyName = "CourseId")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ModuleIds")]
        public List<int> Modules { get; set; }
     }
}
