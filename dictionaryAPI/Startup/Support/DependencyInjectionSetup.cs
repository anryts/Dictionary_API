﻿using System.Text;
using dictionaryAPI.Clients;
using dictionaryAPI.Repositories;
using dictionaryAPI.Support;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Filters;
using tg_api.Support;

public static class DependencyInjectionSetup
{
    public static IServiceCollection AddDependencyInjectionSetup(this IServiceCollection services)
    {
        services.AddCors(); // Make sure you call this previous to AddMvc
        services.AddMvc();

        services.AddSingleton<IMongoClient>(serviceProvider =>
        {
            var settings = MongoClientSettings.FromConnectionString(Links._mongo_link); ;
            return new MongoClient(settings);
        });
    
        services.AddSingleton<IDBRepository, MongoDBRepository>();
        services.AddControllers();
        //services.UseAuth();
        services.AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "dictionaryAPI", Version = "v1" });
            /*swaggerGenOptions.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standart Authorization header (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });*/
                
            swaggerGenOptions.OperationFilter<SecurityRequirementsOperationFilter>();
                
        });
        services.AddSingleton<IDictionaryClient,DictionaryClient>();
        return services;
    }
}