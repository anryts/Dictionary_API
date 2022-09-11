using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tg_api.Support;

/*namespace dictionaryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencyInjectionSetup();
var app = builder.Build();
app.GetMapEndpoint();
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger().UseHttpsRedirection();
}


app.Run();


//builder.Services.Configure<MvcOptions>();