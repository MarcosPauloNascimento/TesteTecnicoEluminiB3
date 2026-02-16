
using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web;
using Swashbuckle.Swagger;
using Swashbuckle.Application;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(TesteTecnicoEluminiB3.Services.Api.App_Start.SwaggerConfig), "Register")]

namespace TesteTecnicoEluminiB3.Services.Api.App_Start
{
    //using Swashbuckle.Application; // EnableSwagger, EnableSwaggerUi
    //using Swashbuckle.Swagger;    // filtros/customizações

    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    // Metadados da API
                    c.SingleApiVersion("v1", "Teste Pratico - Elumini - B3 API")
                     .Description("Documentação da Calculadora de Investimento (Web API 2/.NET Framework 4.8)")
                     .Contact(cc => cc.Name("Marcos Paulo").Email("marcos.paulo.nascimento1@gmail.com"));

                    // Suporte a rotas por atributo
                    c.UseFullTypeNameInSchemaIds();

                    // Resolver conflitos de ações com a mesma rota (se ocorrer)
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    // Incluir comentários XML (para descrever controllers e actions)
                    var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin",
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.XML");
                    if (File.Exists(xmlPath))
                        c.IncludeXmlComments(xmlPath);

                    // (Opcional) JWT Bearer no header Authorization
                    //c.ApiKey("JWT")
                    // .Description("Cabeçalho Authorization usando o esquema Bearer. Ex: 'Bearer {token}'")
                    // .Name("Authorization")
                    // .In("header");

                    // (Opcional) Descrição global de segurança
                    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                    c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                })
                .EnableSwaggerUi(c =>
                {
                    // Habilitar caixa de texto do Authorization: Bearer <token>
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }

    /// <summary>
    /// Adiciona ' (Autorização: Requer token)' no summary quando a action tem [Authorize].
    /// </summary>
    public class AppendAuthorizeToSummaryOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, System.Web.Http.Description.ApiDescription apiDescription)
        {
            var hasAuthorize =
                apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>().Count > 0
                || apiDescription.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AuthorizeAttribute>().Count > 0;

            if (hasAuthorize)
            {
                operation.summary = (operation.summary ?? string.Empty) + " (Requer autorização)";
            }
        }
    }

    /// <summary>
    /// Garante o parâmetro Authorization no header quando necessário.
    /// </summary>
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, System.Web.Http.Description.ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new System.Collections.Generic.List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                required = false,
                description = "Ex.: Bearer {seu_token_jwt}"
            });
        }
    }
}

