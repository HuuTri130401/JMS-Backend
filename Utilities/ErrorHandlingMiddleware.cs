using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Utilities
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case AggregateException e:
                        response.StatusCode = (int)HttpStatusCode.Locked;
                        break;
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case InvalidCastException e:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case EntryPointNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case TimeoutException e:
                        response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                        break;
                    default:
                        {
                            var RouteData = context.Request.Path.Value.Split("/");
                            string apiName = string.Empty;
                            string actionName = string.Empty;

                            if (RouteData.Count() >= 2)
                                apiName = RouteData[1];
                            if (RouteData.Count() >= 3)
                                actionName = RouteData[2];

                            _logger.Error(string.Format("{0} {1}: {2}", apiName
                                , actionName, error?.Message));
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }
                        break;
                }
                var result = JsonSerializer.Serialize(new AppDomainResult()
                {
                    ResultCode = response.StatusCode,
                    ResultMessage = error?.Message,
                    Success = false
                });
                await response.WriteAsync(result);
            }
        }
    }
}
