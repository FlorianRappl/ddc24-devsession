namespace DisneySharpDebugger;

public class Module : IMfModule
{
    public Task Setup(IMfAppService app)
    {
        return Task.CompletedTask;
    }

    public Task Teardown(IMfAppService app)
    {
        return Task.CompletedTask;
    }

    public void Configure(IServiceCollection services)
    {
    }
}
