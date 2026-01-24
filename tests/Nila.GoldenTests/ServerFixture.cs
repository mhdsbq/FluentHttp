using Nila;

class ServerFixture : IAsyncLifetime
{
    public NilaServer Server { get; private set; } = default!;

    public async Task InitializeAsync()
    {
        Server = new NilaServer();
        Server.ProcessAsync(async (ctx, ct) =>
        {
            // Register each golden endpoint from golden data.  

        });

        Server.Start(new()
        {
            Port = 1025
        });
    }

    public Task DisposeAsync()
    {
        Server.Stop();
        // TODO: Make server start and stop sync. Use Idisposeble instead of asynclifetime.
        return Task.CompletedTask;
    }
}