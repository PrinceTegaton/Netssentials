using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace Netssentials.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        public readonly ILogger Logger;
        private readonly IWebHostEnvironment _env;

        public BaseController(ILogger logger, IWebHostEnvironment env)
        {
            Logger = logger;
            _env = env;
        }

        protected ApiResponse<T> BuildValidationResponse<T>(ApiResponse<T> obj)
        {
            var errors = this.GetModelStateValidationErrorsAsList();
            obj.Errors = errors.Any() ? errors : null;
            obj.Message = errors.Any() ? errors.FirstOrDefault() : null;

            return obj;
        }

        protected List<string> GetModelStateValidationErrorsAsList()
        {
            var message = ModelState.Values.SelectMany(a => a.Errors).Select(e => e.ErrorMessage);
            var list = new List<string>();
            list.AddRange(message);
            return list;
        }

        protected string GetModelStateValidationErrors()
        {
            string message = string.Join(";", ModelState.Values
                                    .SelectMany(a => a.Errors)
                                    .Select(e => e.ErrorMessage));
            return message;
        }

        protected string GetModelStateValidationError()
        {
            string message = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
            return message;
        }

        protected IActionResult HandleError(Exception ex, string customErrorMessage = null)
        {
            ApiResponse rsp = new ApiResponse { Code = "500" };

            Logger.LogError(ex, customErrorMessage);

            if (_env.IsDevelopment())
            {
                rsp.Message = $"{(ex?.InnerException?.Message ?? ex.Message)} --> {ex?.StackTrace}";
                return StatusCode(StatusCodes.Status500InternalServerError, rsp);
            }
            else
            {
                rsp.Message = customErrorMessage ?? "An error occurred while processing your request!";
                return StatusCode(StatusCodes.Status500InternalServerError, rsp);
            }
        }
    }
}
