﻿using DatabaseLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using MeterMonitoring.Data.Services.Abstractions;
using MeterMonitoring.Library.Dtos;

namespace MeterMonitoring.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterController : BaseController
    {
        private readonly IMeterService service;
        private readonly ILogger<MeterController> logger;

        public MeterController(ILogger<MeterController> logger, IMeterService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet("meter-list-by-serial/{serialNumber}")]
        public async Task<IActionResult> GetMeterList([FromRoute] string serialNumber, CancellationToken cancellationToken)
        {
            var result = await service.GetMeterListBySerialNumber(serialNumber, cancellationToken);
            return ApiResult(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddMeterReading([FromBody] AddMeterDto data, CancellationToken cancellationToken)
        {
            var result = await service.Add(data, cancellationToken);
            return ApiResult(result);
        }

    }
}
