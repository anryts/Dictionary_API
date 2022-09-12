using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using tg_api.Support;

var builder = WebApplication.CreateBuilder(args);
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
       
builder.Services.AddDependencyInjectionSetup();

var app = builder.Build();
app.GetMapEndpoint();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger().UseHttpsRedirection();
}




app.Run();


//builder.Services.Configure<MvcOptions>();