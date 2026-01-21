using FluentHttp;

var server = new HttpServer();

server.Handle("GET", "/health", (req, res) => res.Write(200));

server.Listen("127.0.0.1", 7007);