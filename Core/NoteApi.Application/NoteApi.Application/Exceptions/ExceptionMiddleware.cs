using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NoteApi.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext Httpcontext, RequestDelegate next)
        {
            try
            {
                await next(Httpcontext);
            }
            catch (Exception ex)
            {

            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statuscode = GetStatusCode(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statuscode;

            List<string> errors = new List<string>()
            {
                $"Hata Mesajı : { ex.Message}",
                $"Mesaj Açıklaması {ex.InnerException?.ToString()}"
            };
            return context.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statuscode
            }.ToString());

        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError

            };


        
    }
}
