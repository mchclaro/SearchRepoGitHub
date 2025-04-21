using SearchRepoGitHub.Infrastructure.Interfaces;
using SearchRepoGitHub.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using SearchRepoGitHub.Application.Services;
using SearchRepoGitHub.Domain.Interfaces;
using SearchRepoGitHub.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuraçao do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SearchRepoGitHub API",
        Version = "v1",
        Description = "API para buscar reposit�rios no GitHub",
        Contact = new OpenApiContact
        {
            Name = "Michel Claro",
            Url = new Uri("https://github.com/mchclaro")
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

builder.Services.AddHttpClient<IGitHubClient, GitHubClient>();
builder.Services.AddScoped<IRepositoryService, RepositoryService>();
builder.Services.AddSingleton<IFavoriteRepository, InMemoryFavoriteRepository>();

var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchRepoGitHub API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<SearchRepoGitHub.API.Middleware.ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
