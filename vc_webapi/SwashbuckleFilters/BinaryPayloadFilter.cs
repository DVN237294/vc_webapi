using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc_webapi.Attributes;

namespace vc_webapi.SwashbuckleFilters
{
    public class BinaryPayloadFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<BinaryPayloadAttribute>().FirstOrDefault();

            if (attribute == null)
                return;

            if (operation.RequestBody == null) 
                operation.RequestBody = new OpenApiRequestBody();

            operation.RequestBody.Content.Add(attribute.MediaType, new OpenApiMediaType()
            {
                Schema = new OpenApiSchema { Type = "string", Format = attribute.Format }
            });
            operation.RequestBody.Required = attribute.Required;
            operation.RequestBody.Description = attribute.ParameterName;
        }
    }
}
