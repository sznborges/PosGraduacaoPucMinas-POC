using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gestor.Dashboard.Api.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "X-API-KEY";

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var apiKey = configuration.GetValue<string>("Application:ApiKey");

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.Result = NotAuthorizedContent();

                return;
            }

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = NotAuthorizedContent();
                return;
            }

            await next();
        }

        private ContentResult NotAuthorizedContent()
        {
            return new ContentResult()
            {
                StatusCode = 401,
                Content = "Not Authorized"
            };
        }
    }
}
