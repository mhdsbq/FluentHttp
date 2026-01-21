namespace FluentHttp;

public class HttpServer : IHttpServer
{
    public void Listen(string ip, int port)
    {
        throw new NotImplementedException();
    }

    public void Handle(string method, string path, Action<HttpRequest, HttpResponse> handler)
    {
        throw new NotImplementedException();
    }
}
