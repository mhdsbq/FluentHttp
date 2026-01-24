namespace Nila;

public class HttpContext
{
    public HttpRequest Request { get; init; }
    public HttpResponse Response { get; init; }

    internal HttpContext(HttpRequest request, HttpResponse response)
    {
        Request = request;
        Response = response;
    }
}

