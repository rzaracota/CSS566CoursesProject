using Backend_Api.Repo_Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository
{
    /**
     * A custom serializer/deserializer for ModuleBaseType and its
     * subclasses.
     */
    public class ModuleBaseTypeConverter : JsonConverter
    {
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<ModuleBaseContent>);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        List<ModuleBaseContent> layoutList = new List<ModuleBaseContent>();
        JArray tokens = JArray.Load(reader);

        foreach (JToken token in tokens)
        {
            if (token["Type"] != null)
                {
                    if (token["Type"].ToString().Equals("text"))
                    {
                        layoutList.Add(token.ToObject<ModuleTextContent>());
                    }
                    else if (token["Type"].ToString().Equals("video"))
                    {
                        layoutList.Add(token.ToObject<ModuleVideoContent>());
                    }
                    else if (token["Type"].ToString().Equals("image"))
                    {
                        layoutList.Add(token.ToObject<ModuleImageContent>());
                    }
                    else if (token["Type"].ToString().Equals("quiz"))
                    {
                        layoutList.Add(token.ToObject<ModuleQuizContent>());
                    }
                    else
                    {
                        throw new Exception("Unsupported Type: " + token["Type"]);
                    }
                }
                else
                {
                    throw new Exception(
                        "Expected JSON to contain Type field");
                }
            }


        return layoutList;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        List<ModuleBaseContent> list = (List<ModuleBaseContent>) value;
        serializer.Serialize(writer, list);
    }

    public override bool CanWrite
    {
        get { return true; }
    }
}
}
