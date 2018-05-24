using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Backend_Api
{
    public class PolymorphismDocumentFilter<T> : IDocumentFilter
    {
        private static void RegisterSubClasses(ISchemaRegistry schemaRegistry, Type abstractType)
        {
            const string discriminatorName = "discriminator";

            var parentSchema = schemaRegistry.Definitions[abstractType.Name];

            //set up a discriminator property (it must be required)
            //parentSchema.Discriminator = discriminatorName;
            //parentSchema.Required = new List<string> { discriminatorName };

            //if (!parentSchema.Properties.ContainsKey(discriminatorName))
            //    parentSchema.Properties.Add(discriminatorName, new Schema { Type = "string" });

            //register all subclasses
            var derivedTypes = abstractType.Assembly
                                           .GetTypes()
                                           .Where(x => abstractType != x && abstractType.IsAssignableFrom(x));

            foreach (var item in derivedTypes)
                schemaRegistry.GetOrRegister(item);
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            RegisterSubClasses(context.SchemaRegistry, typeof(T));
        }
    }
}
