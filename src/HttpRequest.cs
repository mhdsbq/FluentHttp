namespace FluentHttp;

public class HttpRequest
{
    public int StatusCode { get; init; }
    public Dictionary<string, string> Headers { get; init; } = default!;
    public HttpRequestBody Body { get; init; } = default!;
}

public class HttpRequestBody
{
    public async Task<T> AsJsonAsync<T>()
    {
        throw new NotImplementedException();
    }
}