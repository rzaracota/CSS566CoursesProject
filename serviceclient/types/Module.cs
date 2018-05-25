using System.Collections.Generic;
using System.Runtime.Serialization;

namespace serviceclient.types {
    [DataContract]
    public class Module {
        [DataMember]
        public string ModuleId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public List<string> CourseIds { get; set; }
        
        [DataMember (Name = "Layout")]
        public List<ModuleBaseContent> ModuleContent { get; set; }
    }
}