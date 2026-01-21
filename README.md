# FluentHttp
A tiny, DI-less HTTP server library for C#.

## Introduction
This is a project for learning and experimenting with building an HTTP server using TCP sockets in c#.
It aims to provide a simple interface for handling HTTP. Implements a subset of HTTP/1.1 features.

## Goals
- Simple
- Fast
- Explicit

## Spec supported
See [HTTP Specification for FluentHttp](docs/spec.md) for details.

## Usage (Planned)

```csharp
using FluentHttp;

var app = new HttpServer();

app.Handle("GET", "/ping", (req, res) =>
{
    res.Write(200, "pong");
});

app.Handle("GET", "/users/{id}", (req, res) =>
{
    var userId = req.RouteParams["id"];
    res.Write(200, $"User ID: {userId}");
});

app.Handle("POST", "/users", async (req, res) =>
{
    var user = await req.Body.AsJsonAsync<User>();
    res.Write(201, user);
});

app.Listen("127.0.0.1", port: 8080);
```