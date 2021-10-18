using System.Collections.Generic;

namespace api.Models
{
  public class CheckFieldViewModelOutput
  {
    public IEnumerable<string> Errors { get; set; }

    public CheckFieldViewModelOutput(IEnumerable<string> errors)
    {
      Errors = errors;
    }
  }
}