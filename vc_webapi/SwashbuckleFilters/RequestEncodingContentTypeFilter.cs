using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc_webapi.Attributes;

namespace vc_webapi.SwashbuckleFilters
{
    public class RequestEncodingContentTypeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<RequestEncodingContentTypeAttribute>().FirstOrDefault();

            if (attribute == null)
                return;
            if (operation.RequestBody == null) operation.RequestBody = new OpenApiRequestBody();

            if(operation.RequestBody.Content.TryGetValue(attribute.MediaType, out OpenApiMediaType mediaType))
            {
                for(int i = 0; i < attribute.ParameterNames.Length && i < attribute.ContentTypes.Length; i++)
                {
                    if (mediaType.Encoding.TryGetValue(attribute.ParameterNames[i], out OpenApiEncoding encoding))
                        encoding.ContentType = attribute.ContentTypes[i];
                    else
                        mediaType.Encoding.Add(attribute.ParameterNames[i], new OpenApiEncoding() { ContentType = attribute.ContentTypes[i] });
                }
            }
        }
    }
}
