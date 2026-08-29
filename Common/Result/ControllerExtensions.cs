using Microsoft.AspNetCore.Mvc;

namespace ResultMetrics.Common.Result;

public static class ControllerExtensions
{
    public static IActionResult ToActionResult(
        this ControllerBase controller,
        Result result)
    {
        if (result.Successful)
        {
            return controller.StatusCode((int)result.StatusCode);
        }

        return controller.StatusCode(
            (int)result.StatusCode,
            result.Fault);
    }

    public static IActionResult ToActionResult<TValue>(
        this ControllerBase controller,
        Result<TValue> result)
    {
        if (result.Successful)
        {
            return controller.StatusCode(
                (int)result.StatusCode,
                result.Value);
        }

        return controller.StatusCode(
            (int)result.StatusCode,
            result.Fault);
    }
}