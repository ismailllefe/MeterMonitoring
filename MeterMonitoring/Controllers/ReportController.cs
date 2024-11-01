using DatabaseLibrary.Data;
using MeterMonitoring.Data.Services.Abstractions;
using MeterMonitoring.Library.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MeterMonitoring.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : BaseController
    {
        private readonly IReportService service;
        private readonly ILogger<ReportController> logger;

        public ReportController(ILogger<ReportController> logger, IReportService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpPost("request")]
        public async Task<IActionResult> CreateRequest([FromBody] NewClientRequestDto data, CancellationToken cancellationToken)
        {
            var result = await service.Create(data, cancellationToken);
            return ApiResult(result);
        }

    }
}
