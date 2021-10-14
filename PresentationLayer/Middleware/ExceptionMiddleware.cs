using log4net;
using Microsoft.AspNetCore.Http;
using PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PresentationLayer.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionMiddleware));
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            Dictionary<string, List<string>> exceptionList = new Dictionary<string, List<string>>();
            List<string> exceptioItem = new List<string>();
            int i = 0;
            if (ex.GetType() == typeof(AggregateException))
            {
                foreach (var err in ((AggregateException)ex).Flatten().InnerExceptions)
                {
                    var innerEx = err;
                    while (!(innerEx.InnerException == null))
                    {
                        innerEx = innerEx.InnerException;
                    }
                    var key = (innerEx.GetType() == typeof(ValidationException) ? ((ValidationException)innerEx).Value : i++).ToString();
                    if (exceptionList.ContainsKey(key))
                    {
                        exceptioItem = exceptionList[key];
                        exceptionList.Remove(key);
                        exceptioItem.Add(innerEx.Message);
                        exceptionList.Add(key, exceptioItem);
                    }
                    else
                    {
                        exceptioItem = new List<string>();
                        exceptioItem.Add(innerEx.Message);
                        exceptionList.Add(key, exceptioItem);
                    }
                }
            } else
            {
                while (!(ex.InnerException == null))
                {
                    ex = ex.InnerException;
                }
                exceptioItem.Add(ex.Message);
                exceptionList.Add((ex.GetType() == typeof(ValidationException) ? ((ValidationException)ex).Value : i++).ToString(), exceptioItem);
            }

            return context.Response.WriteAsync(new ErrorDetails()
            {
                Status = context.Response.StatusCode,
                Title = "Internal Server Error",
                Errors = exceptionList
            }.ToString());
        }
    }
}
