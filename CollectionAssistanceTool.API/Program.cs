using CollectionAssistanceTool.API.Services;
using CollectionAssistanceTool.API.Services.impl;
using CollectionAssistanceTool.Infrastructure.Repositories;
using CollectionAssistanceTool.Infrastructure.Repositories.impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IColumnRepository, ColumnRepositoryGAS>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    var baseUrl = configuration["GoogleAppsScript:BaseUrl_Column"];
    return new ColumnRepositoryGAS(httpClient, baseUrl);
});
builder.Services.AddSingleton<IRecordRepository, RecordRepositoryGAS>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var configuration = provider.GetRequiredService<IConfiguration>();
    var baseUrl = configuration["GoogleAppsScript:BaseUrl_Record"];
    return new RecordRepositoryGAS(httpClient, baseUrl);
});
builder.Services.AddScoped<IColumnService, ColumnService>();
builder.Services.AddScoped<IRecordService, RecordService>();

builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// Use CORS
app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
