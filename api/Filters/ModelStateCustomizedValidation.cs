using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace curso.api.Filters
{
  public class ModelStateCustomizedValidation : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        var checkFieldViewModelOutput = new CheckFieldViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
        context.Result = new BadRequestObjectResult(checkFieldViewModelOutput);
      }
    }
  }
}