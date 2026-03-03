using ERPApplication.ApplicationLayer.Common;
using Microsoft.AspNetCore.Mvc;

namespace ERPApplication.PresentationLayer.HelperMethods
{
    public class ResultMapper
    {
        public static IActionResult ReturnResult(Result result)
        {
            switch (result.Error.ErrorCode)
            {
                case ErrorType.None:
                    return new OkResult();
                case ErrorType.NotFound:
                    return new NotFoundObjectResult(result.Error.Message);
                case ErrorType.FailedUpdate:
                case ErrorType.InvalidData:
                case ErrorType.InvalidOperation:
                    return new BadRequestObjectResult(result.Error.Message);
                case ErrorType.UnauthorisedOperation:
                    return new UnauthorizedObjectResult(result.Error.Message);
                default:
                    return new BadRequestObjectResult("Something went wrong");
            }
        }
        public static IActionResult ReturnResult<T>(Result<T> result)
        {
            switch (result.Error.ErrorCode)
            {
                case ErrorType.None:
                    return new OkObjectResult(result.GetValue());
                case ErrorType.NotFound:
                    return new NotFoundObjectResult(result.Error.Message);
                case ErrorType.UnauthorisedOperation:
                    return new UnauthorizedObjectResult(result.Error.Message);
                case ErrorType.FailedUpdate:
                case ErrorType.InvalidData:
                case ErrorType.InvalidOperation:
                    return new BadRequestObjectResult(result.Error.Message);
                default:
                    return new BadRequestObjectResult("Something went wrong");
            }
        }
    }
}
