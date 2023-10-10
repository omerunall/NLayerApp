using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;

namespace NLayer.API.Filter
{
    public class ValidatorFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Values.SelectMany(x => x.Errors).Select(s => s.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(CustomResponseDTO<NoContentDTO>.Fail(400, error));

            }
        }
    }
}
