﻿using GloboTicket.TicketManagement.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
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
                await ConvertException(context, ex);
                Log.Error(ex, "Something went wrong!");
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;
            if(result==string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }
            return context.Response.WriteAsync(result);
        }
    }
}
