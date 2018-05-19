using System.Runtime.Serialization;

namespace serviceclient.types
{
    [DataContract]
    public class CourseModule
    {
        [DataMember]
        public int CourseId { get; set; }

        [DataMember]
        public int ModuleId { get; set; }
    }
}