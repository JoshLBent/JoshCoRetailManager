using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

// StackOverflow source
// https://www.youtube.com/redirect?redir_token=QUFFLUhqa24yY2Q4M1JUc2RuX1Z1NWJtTUYzUTI2S0V5QXxBQ3Jtc0tsTjFxOHdRZ0pGaGFtejY3Y29zRlkxRThZc19iWTdiU1hHWHYtMThmbVV2UzNCU2ViU0dWbjZjOEpoN0NDSFJjbFUxS055S0dMZEtZdm1iX05RWWZpb3JZWHpIdmktOTBDd3JxcnlzM0ZRSkdmVzdPUQ%3D%3D&q=https%3A%2F%2Fstackoverflow.com%2Fquestions%2F51117655%2Fhow-to-use-swagger-in-asp-net-webapi-2-0-with-token-based-authentication&event=comments&stzid=UgzhuhpgksQKeVNNs7Z4AaABAg

namespace JRMDataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem 
            {
                post = new Operation
                {
                    tags = new List<string> { "Auth" },
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = true,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = true,
                            @in = "formData"
                        }
                    }
                }
            });
        }
    }
}