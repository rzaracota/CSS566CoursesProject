using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Software_Management_Course_Website.Models
{
    [DataContract]
    public class Course
    {
        [JsonProperty(PropertyName = "CourseId")]
        [DataMember (Name = "CourseId")]
        public string CourseId { get; set; }

        [JsonProperty(PropertyName = "Name")]
        [DataMember (Name = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ModuleIds")]
        [DataMember(Name = "ModuleIds")]
        public List<int> Modules { get; set; }
     }
}
