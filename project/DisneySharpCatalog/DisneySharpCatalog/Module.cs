namespace DisneySharpCatalog;

public class Module : IMfModule
{
    public void Configure(IServiceCollection services)
    {
        // Configure your services in this function
    }

    public Task Setup(IMfAppService app)
    {
        app.AppendScript("swipe.js");

        app.MapComponent<MoviesNavLink>("nav-items");
        app.MapComponent<TvShowsNavLink>("nav-items");

        app.MapRoute<MoviesPage>();
        app.MapRoute<TvShowsPage>();

        return Task.CompletedTask;
    }

    public Task Teardown(IMfAppService app)
    {
        // Unregister things that need to be cleaned up
        return Task.CompletedTask;
    }
}