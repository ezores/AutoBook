using System.Text.Json;

namespace UstamOgretiyorBize.Exceptions;

public class HttpException : Exception
{
    public HttpException(string message = "Internal Server Error",int statusCode = StatusCodes.Status500InternalServerError): base(message)
    {
        StatusCode = statusCode ;
    }

    public int StatusCode{get;}
    
}