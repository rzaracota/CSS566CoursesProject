using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Software_Management_Course_Website.Models
{
    public class RootObject
    {
        /* [JsonProperty("Module")]
        public Module Module { get; set; } */
        public serviceclient.types.Module Module { get; set; }
    }

    [DataContract]
    public class Module
    {
        [JsonProperty("ModuleId")]
        [DataMember(Name = "ModuleId")]
        public string ModuleID { get; set; }
        [JsonProperty("Title")]
        [DataMember(Name = "Title")]
        public string Title { get; set; }
        [JsonProperty("Author")]
        [DataMember(Name = "Author")]
        public string Author { get; set; }
        [JsonProperty("Courses")]
        [DataMember(Name = "Courses")]
        public List<string> Courses { get; set; }
        [JsonProperty("Layout")]
        [DataMember(Name = "Layout")]
        public List<LayoutCommon> Layout { get; set; }
    }

    [DataContract]
    public class LayoutCommon
    {
        [JsonProperty("heading")]
        [DataMember(Name = "heading")]
        public string Heading { get; set; }
        [JsonProperty("type")]
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [JsonProperty("link")]
        [DataMember(Name = "link")]
        public string Link { get; set; }
        [JsonProperty("caption")]
        [DataMember(Name = "caption")]
        public string Caption { get; set; }
        [JsonProperty("text")]
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }

    //public class MediaLayout: LayoutCommon
    //{

    //}

    //public class TextLayout : LayoutCommon
    //{
       
    //}
}
