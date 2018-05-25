using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Software_Management_Course_Website.Models
{
    public class Module
    {
        [JsonProperty(PropertyName = "ModuleId")]
        public int ModuleID { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "CourseIds")]
        public List<int> Courses { get; set; }

        public List<string> Keywords { get; set; }

        [JsonProperty(PropertyName = "Layout")]
        public List<Content> Layout { get; set; }

    }

    public class Content
    {
        [JsonProperty(PropertyName = "heading")]
        public String Heading { get; set; }

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "text")]
        public String Text { get; set; }

        [JsonProperty(PropertyName = "link")]
        public String Link { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public String Caption { get; set; }
    }
}
