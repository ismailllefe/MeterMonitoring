using MeterMonitoring.Library;
using Microsoft.AspNetCore.Mvc;

namespace MeterMonitoring.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ApiResult<T>(ApiResult<T> result)
        {
            if (result.State == State.Error)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        protected IActionResult ApiResult(ApiResult result)
        {
            if (result.State == State.Error)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
