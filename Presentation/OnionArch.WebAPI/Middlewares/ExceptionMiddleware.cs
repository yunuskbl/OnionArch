using System.Net;
using System.Text.Json;
using OnionArch.APPLICATION.Exceptions;

namespace OnionArch.WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var message = "Sunucuda Bir Hata Oluştu";

            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                case ValidationException:
                    code = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
            }
            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
