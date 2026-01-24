using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Nila;

public class NilaServer
{
    private TcpListener? _listener;
    private Func<HttpContext, CancellationToken, Task>? _handler;
    public void Start(ServerOptions options)
    {
        _listener = new TcpListener(IPAddress.Loopback, options.Port);
        _listener.Start();
        AcceptConnections();
    }

    public void ProcessAsync(Func<HttpContext, CancellationToken, Task> handler)
    {
        _handler = handler;
    }

    public void Stop()
    {
        Debug.Assert(_listener is not null);

        // TODO: Implement token cancellation
        _listener.Stop();
    }

    private void AcceptConnections()
    {
        Debug.Assert(_listener is not null);

        while (true)
        {
            var tcpClient = _listener.AcceptTcpClient();
            _ = HandleConnectionAsync(tcpClient);
        }
    }

    private async Task HandleConnectionAsync(TcpClient tcpClient)
    {
        Debug.Assert(_handler is not null);

        var stream = tcpClient.GetStream();
        var reader = new StreamReader(stream);
        var writer = new StreamWriter(stream);

        var request = new HttpRequest(reader);
        await request.ParseAsync();

        var response = new HttpResponse(writer, request.Protocol);
        var context = new HttpContext(request, response);

        // TODO: Create cancellation token source 
        await _handler.Invoke(context, CancellationToken.None);

        await response.FlushAsync();
        tcpClient.Close();
    }
}