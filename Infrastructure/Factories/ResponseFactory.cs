

using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ResponseFactory
{
    //succeeded
    public static ResponsResult Ok()
    {
        return new ResponsResult
        {

            Message ="Succeeded",
            StatusCode = StatusCode.OK
        };
    }
    //message
    public static ResponsResult Ok(string? message = null)
    {
        return new ResponsResult
        {
            Message = message ?? "Succeeded",
            StatusCode = StatusCode.OK
        };
    }
    //obj and message
    public static ResponsResult Ok(object? obj, string? message = null)
    {
        return new ResponsResult
        {
            ContentResult = obj,
            Message = message ?? "Succeeded",
            StatusCode = StatusCode.OK
        };
    }

    public static ResponsResult Error(string? message = null)
    {
        return new ResponsResult
        {
            Message = message ?? "Failed",
            StatusCode = StatusCode.ERROR
        };
    }

    public static ResponsResult NotFound(string? message = null)
    {
        return new ResponsResult
        {
            Message = message ?? "Not Found",
            StatusCode = StatusCode.NOT_FOUND
        };
    }

    public static ResponsResult Exist(string? message = null)
    {
        return new ResponsResult
        {
            Message = message ?? "Already Exists",
            StatusCode = StatusCode.EXIST
        };
    }
}
