using Microsoft.AspNetCore.Builder;

namespace tg_api.Support;

public static class MapEndpoints
{
    public static WebApplication GetMapEndpoint(this WebApplication app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        return app;
    }
}