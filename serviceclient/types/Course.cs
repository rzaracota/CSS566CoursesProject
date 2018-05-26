using System.Collections.Generic;
using System.Runtime.Serialization;

namespace serviceclient.types
{
    public class Course
    {
        public Course()
        {
            ModuleIds = new List<string>();
        }

        [DataMember (Name = "CourseId")]
        public string CourseId { get; set; }

        [DataMember (Name = "Name")]
        public string Name { get; set; }

        [DataMember]
        public List<string> ModuleIds { get; set; }
    }
}