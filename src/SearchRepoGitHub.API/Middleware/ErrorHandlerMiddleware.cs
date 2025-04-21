using System.Net;
using System.Text.Json;

namespace SearchRepoGitHub.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<ErrorHandlerMiddleware>>();
            logger.LogError(exception, "Ocorreu um erro inesperado.");

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorMessage = "Ocorreu um erro interno no servidor.";

            // Trata erros de validação
            if (exception is ArgumentException validationException)
            {
                statusCode = HttpStatusCode.BadRequest;
                errorMessage = validationException.Message;
            }

            // Cria a resposta JSON
            var response = new
            {
                error = errorMessage,
                statusCode = (int)statusCode
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
