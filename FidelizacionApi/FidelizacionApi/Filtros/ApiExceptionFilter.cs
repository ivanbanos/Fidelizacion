using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Aplicacion.Exepciones;

namespace FidelizacionApi.Filtros
{
    public class ApiExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ApiException exception)
            {
                context.Result = new ObjectResult(exception.Message) { 
                 StatusCode = (int)exception.StatusCode,
                };

            context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

    }
}
