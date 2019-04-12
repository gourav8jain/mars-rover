using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.Common.Infrastructure.Common.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace MarsRoverApp.WebApi.Implementation.Filters
{
    public class InputValidationFilter : IActionFilter
    {
        private IValidator _validator;
        public InputValidationFilter(IValidator validator)
        {
            this._validator = validator;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var rovelModel = (RoverModel)context.ActionArguments.Values.FirstOrDefault();
            if (!this._validator.IsValid(rovelModel))
            {
                throw new Exception("Not valid");
            }
            // our code before action executes
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
