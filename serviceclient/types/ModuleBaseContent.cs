using System.Runtime.Serialization;

namespace serviceclient.types
{
    [DataContract]
    public class ModuleBaseContent
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string Caption { get; set; }
        
        [DataMember]
        public string Heading { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}