using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Service.Common;

namespace WebAPI.Filters
{
    public class ValidateModelAttribute: ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = "";

                foreach (var modelState in context.ModelState)
                {
                    errors += string.Join(",", modelState.Value.Errors.Select(a => a.ErrorMessage).ToArray());
                }

                var apiResponse = new ResponseModel<bool>
                {
                    Error = true,
                    Message = errors
                };

                context.Result = new BadRequestObjectResult(apiResponse);
            }

            base.OnResultExecuting(context);
        }
    }
}
