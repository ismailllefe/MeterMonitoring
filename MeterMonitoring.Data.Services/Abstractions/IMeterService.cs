using MeterMonitoring.Dtos;
using MeterMonitoring.Library;
using MeterMonitoring.Library.Dtos;

namespace MeterMonitoring.Data.Services.Abstractions;
public interface IMeterService
{
    Task<ApiResult<List<MeterListResultDto>>> GetMeterListBySerialNumber(string serialNumber, CancellationToken cancellationToken);
    Task<ApiResult<bool>> Add(AddMeterDto data, CancellationToken cancellationToken);
}

