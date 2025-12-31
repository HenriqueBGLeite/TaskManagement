using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManagement.Communication.Excepetions;
using TaskManagement.Communication.Responses;

namespace TaskManagement.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TaskManagementException taskManagementException)
        {
            context.HttpContext.Response.StatusCode = (int)taskManagementException.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson(taskManagementException.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro desconhecido."));
    }
}
