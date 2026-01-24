using Nila;

var server = new NilaServer();

server.ProcessAsync(async (ctx, ct) =>
{
    ctx.Response.StatusCode = 204;
    ctx.Response.ReasonPhrase = "No Content";
});

server.Start(new() { Port = 8080 });