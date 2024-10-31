using System.Text.Json.Serialization;

namespace MeterMonitoring.Library;
public class ApiResult
{
    public ApiResult(string message = "", State state = State.Success)
    {
        Message = message;
        State = state;
    }

    public string Message { get; set; }
    public State State { get; set; }
}

public class ApiResult<T> : ApiResult
{
    [JsonConstructor]
    public ApiResult(T result, string message = "", State state = State.Success) : base(message, state)
    {
        Result = result;
    }

    public T Result { get; set; }
}
