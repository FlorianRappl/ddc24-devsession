namespace DisneySharpSearch;

public class Module : IMfModule
{
    public Task Setup(IMfAppService app)
    {
        app.MapComponent<SearchFragment>("search");

#if DEBUG
        app.MapComponent<SearchHelperLink>("nav-items");
        app.MapRoute<SearchHelperPage>();
#endif

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
