using System.Runtime.Serialization;

namespace serviceclient.types {
    [DataContract]
    public class Module {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int ModuleId { get; set; }

        [DataMember]
        public string Author { get; set; }
    }
}