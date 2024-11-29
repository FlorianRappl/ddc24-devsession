namespace Catalog;

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
        app.AppendScript("swipe.js");

        app.MapComponent<MoviesNavLink>("nav");
        app.MapComponent<TvShowsNavLink>("nav");
        app.MapRoute<Movies>();
        app.MapRoute<TvShows>();

        // Register components and more
        return Task.CompletedTask;
    }

    public Task Teardown(IMfAppService app)
    {
        // Unregister things that need to be cleaned up
        return Task.CompletedTask;
    }
}
