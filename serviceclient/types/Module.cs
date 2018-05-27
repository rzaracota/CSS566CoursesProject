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
        public List<int> CourseIds { get; set; }
        
        [DataMember]
        public List<string> Keywords { get; set; }

        [DataMember (Name = "Layout")]
        public List<ModuleBaseContent> Layout { get; set; }
    }
}