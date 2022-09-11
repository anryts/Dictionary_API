using Microsoft.AspNetCore.Builder;

namespace tg_api.Support;

public static class SwaggerConfiguration
{
     public static WebApplication ConfigureSwagger(this WebApplication app)
     {
         app.UseSwagger();
         app.UseSwaggerUI(c =>
         {
             c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
         });
         return app;
     }
}