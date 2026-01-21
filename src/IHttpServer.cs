namespace FluentHttp;

internal interface IHttpServer
{
    public void Listen(string ip, int port);
    public void Handle(string method, string path, Action<HttpRequest, HttpResponse> handler);
}