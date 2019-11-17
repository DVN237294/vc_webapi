using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace vc_webapi.SwashbuckleFilters
{
    public class ReadOnlyPropertyFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            foreach (var schemaProperty in model?.Properties)
            {
                var property = context.ApiModel.Type.GetProperty(schemaProperty.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (property != null)
                {
                    if (!property.CanWrite || (property.SetMethod?.IsAssembly ?? false))
                    {
                        // https://github.com/swagger-api/swagger-ui/issues/3445#issuecomment-339649576
                        if (schemaProperty.Value.Reference != null)
                        {
                            schemaProperty.Value.AllOf = new List<OpenApiSchema>
                            {
                                new OpenApiSchema
                                {
                                    Reference = schemaProperty.Value.Reference
                                }
                            };
                            schemaProperty.Value.Reference = null;
                        }
                        schemaProperty.Value.ReadOnly = true;
                    }
                }
            }
        }
    }
}
