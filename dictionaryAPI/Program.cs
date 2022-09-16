using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using tg_api.Support;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencyInjectionSetup();
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
        options.TokenValidationParameters = new TokenValidationParameters
        {
             ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(
                     Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                 ValidateIssuer = false,
                    ValidateAudience = false
        }
    );
       


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger().UseHttpsRedirection();
}
else
{
    app.UseHttpsRedirection();
}
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.GetMapEndpoint();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



app.Run();


//builder.Services.Configure<MvcOptions>();