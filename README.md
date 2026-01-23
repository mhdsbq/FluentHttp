![alt text](logo.svg)

A tiny, DI-less HTTP server library for C#.

## Introduction

This is a project for learning and experimenting with building an HTTP server using TCP sockets in c#.
It aims to provide a simple interface for handling HTTP. Implements a subset of HTTP/1.1 features.

## Goals

- Simple
- Fast
- Explicit

## Spec supported

See [HTTP Specification for Nila](docs/spec.md) for details.

## Usage (Planned)

```csharp
var server = new NilaServer();
server.ProcessAsync(async (ctx, ct) =>
{
    Console.WriteLine($"{ctx.Request.Method} {ctx.Request.Path}");

    ctx.Response.StatusCode = 200;
    ctx.Response.Headers["Content-Type"] = "text/plain";

    // Echo request body
    await foreach (var chunk in ctx.Request.ReadChunksAsync(ct))
    {
        await ctx.Response.Body.WriteAsync(chunk, ct);
    }
});

server.Start(new ServerOptions
{
    Port = 8080
});
```

## Development plan

Using curl's test suite to verify compliance with HTTP/1.1
https://github.com/curl/curl/tree/master/tests

- Setup the dev server in /dev
- Implement curl tests one by one and verify compliance
- Add more features as needed
