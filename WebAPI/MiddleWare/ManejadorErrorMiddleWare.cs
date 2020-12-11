using Aplicacion.ManejadorError;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.MiddleWare
{
    public class ManejadorErrorMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManejadorErrorMiddleWare> _logger;

        public ManejadorErrorMiddleWare(RequestDelegate next, ILogger<ManejadorErrorMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await ManejadorExceptionAsync(context, e, _logger);
            }
        }

        private async Task ManejadorExceptionAsync(HttpContext context, Exception e, ILogger<ManejadorErrorMiddleWare> logger)
        {
            object errores = null;

            switch (e)
            {
                case ManejadorExcepcion me:
                    {
                        logger.LogError(e, "Manejador Error");
                        errores = me.Errores;
                        context.Response.StatusCode = (int)me.Codigo;
                        break;
                    }
                case Exception ex:
                    {
                        logger.LogError(e, "Error de Servidor");
                        errores = string.IsNullOrWhiteSpace(ex.Message) ? "Error" : ex.Message;
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    }
            }

            context.Response.ContentType = "application/jason";

            if (errores != null)
            {
                var resultados = JsonConvert.SerializeObject(new { errores });
                await context.Response.WriteAsync(resultados);
            }
        }
    }
}
