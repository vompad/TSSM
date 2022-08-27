using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FirstTestCase
{ 
    public class logger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public logger(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<logger>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation("Request {method} {url} => {statusCode}",context.Request?.Method, context.Request?.Path.Value,context.Response?.StatusCode);
            using (StreamWriter writer = new StreamWriter("LogsMiddleware1.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} Зашел в метод:{context.Request?.Method}\nВышел из метода{context.Request?.Method} с кодом {context.Response?.StatusCode} ");
            }
        }
        }
    }
}