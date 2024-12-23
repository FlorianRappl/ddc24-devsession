﻿namespace Search;

public class Module : IMfModule
{
    public Module(IConfiguration configuration)
    {
        // Inject here what you want, e.g., the global `IConfiguration`.
    }

    public void Configure(IServiceCollection services)
    {
        // Configure your services in this function
    }

    public Task Setup(IMfAppService app)
    {
        app.AppendScript("scroll.js");

        app.MapComponent<SearchFragment>("search");
        app.MapRoute<SearchPage>();

#if DEBUG
        app.MapComponent<SearchHelperLink>("nav");
        app.MapRoute<SearchHelperPage>();
#endif

        return Task.CompletedTask;
    }

    public Task Teardown(IMfAppService app)
    {
        // Unregister things that need to be cleaned up
        return Task.CompletedTask;
    }
}
