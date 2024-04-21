
namespace Infrastructure.Models;

public enum StatusCode
{
    OK = 200, ERROR = 400, EXIST= 409, NOT_FOUND = 404
}

public class ResponsResult
{
    public Infrastructure.Models.StatusCode StatusCode {  get; set; }

    public object? ContentResult { get; set; }

    public string? Message { get; set; }
}
