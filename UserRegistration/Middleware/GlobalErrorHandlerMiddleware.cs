using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace UserRegistration.Middleware
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger; 
        private readonly IHostEnvironment _environment;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlerMiddleware> logger, IHostEnvironment environment)  
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            try
            {
                await _next(context);

                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    await context.Response.WriteAsync(JsonConvert.SerializeObject( new UnauthorizedAccessException(), settings)); 
                }
            }
            catch (Exception ex)
            {
                var msg = $"\nError Handler Middleware: {DateTimeOffset.UtcNow.ToString()}\n" +
                          $"Request Path: {context.Request.Path}\n" +
                          $"Request method: {context.Request.Method}\n" +
                          $"Error Message: {ex.Message}\n\n";
                _logger.LogError(msg);

                var response = context.Response;
                response.ContentType = "application/json";
                var errorMessage = _environment.IsDevelopment() ? (ex.Message + (ex.InnerException != null ? $" - InnerException - {ex.InnerException.Message}" : "")) : "";
                switch (ex)
                {
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonConvert.SerializeObject(errorMessage, settings);
                await response.WriteAsync(result);
            }
        }
    }
}
