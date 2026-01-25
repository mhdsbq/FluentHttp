using System.Net.Sockets;
using System.Text;

namespace Nila.GoldenTests;

public class GoldenTests : IDisposable
{
    private readonly NilaServer _server;

    public GoldenTests()
    {
        _server = new NilaServer();
        _server.ProcessAsync(async(ctx, ct) =>
        {
            if(ctx.Request.Method == "GET" && ctx.Request.Path == "/")
            {
                ctx.Response.StatusCode = 200;
                ctx.Response.ReasonPhrase = "OK";
            }
            else
            {
                ctx.Response.StatusCode = 404;
                ctx.Response.Headers["Content-Type"] = "text/plain";
                ctx.Response.ReasonPhrase = "Not Found";
                ctx.Response.Headers["Content-Length"] = "9";
                await ctx.Response.WriteBodyAsync("Not Found", ct);
            }
        });

        _server.Start(new() { Port = 2603 });
    }

    [Fact]
    public async Task TestGetRoot_Returns200()
    {
        var request = """
            GET / HTTP/1.1
            Host: localhost:2603
            Connection: close
            """;

        var response = await SendTcpRequest(request);

        var expected = """
            HTTP/1.1 200 OK
            \r\n
            """;

        AssertEqual(expected, response);
    }

    [Fact]
    public async Task TestInvalidPath_Returns404()
    {
        var request = """
            GET /notfound HTTP/1.1
            Host: localhost:2603
            Connection: close
            """;

        var response = await SendTcpRequest(request);

        var expected = """
            HTTP/1.1 404 Not Found
            Content-Type: text/plain
            Content-Length: 9
            
            Not Found
            """;

        AssertEqual(expected, response);
    }

    private async Task<string> SendTcpRequest(string request)
    {
        using var client = new TcpClient("localhost", 2603);
        using var stream = client.GetStream();

        var bytes = Encoding.UTF8.GetBytes(request);
        await stream.WriteAsync(bytes, 0, bytes.Length);

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return await reader.ReadToEndAsync();
    }

    public void Dispose()
    {
        _server.Stop();
    }

    private void AssertEqual(string expected, string response)
    {
        var normalizedExpected = expected.Replace("\n", "\r\n").Replace(@"\r\n", "\r\n");
        Assert.Equal(normalizedExpected, response);
    }
}
