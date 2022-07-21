using Gestor.Dashboard.Api.Middleware;
using Gestor.Dashboard.Application;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerGen(opt =>
{
    var xmlFileApi = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPathApi = Path.Combine(AppContext.BaseDirectory, xmlFileApi);
    opt.IncludeXmlComments(xmlPathApi);

    var caminhoAplicacao = AppContext.BaseDirectory;
    var xmlPathApplication = Path.Combine(AppContext.BaseDirectory, "Gestor.Dashboard.Application.xml");
    opt.IncludeXmlComments(xmlPathApplication);

    opt.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = "X-API-KEY", //header with api key
        Type = SecuritySchemeType.ApiKey,
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
         {
             new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
             },
             new string[] { }
         }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwaggerUI();

app.Run();
