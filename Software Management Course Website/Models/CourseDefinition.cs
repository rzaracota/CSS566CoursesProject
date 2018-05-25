using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Management_Course_Website.Models
{
    public class RootObject
    {
        [JsonProperty("Module")]
        public Module Module { get; set; }
    }

    public class Module
    {
        [JsonProperty("ModuleId")]
        public int ID { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Author")]
        public string Author { get; set; }
        [JsonProperty("Courses")]
        public List<string> Courses { get; set; }
        [JsonProperty("Layout")]
        public List<LayoutCommon> Layout { get; set; }
    }

    public class LayoutCommon
    {
        [JsonProperty("heading")]
        public string Heading { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("caption")]
        public string Caption { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    //public class MediaLayout: LayoutCommon
    //{

    //}

    //public class TextLayout : LayoutCommon
    //{
       
    //}
}
