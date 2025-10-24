using Data.DependencyInjection;
using Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Service.DependencyInjection;
using WebAPI.DependencyInjection;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomHealthChecks(builder.Configuration);

//builder.Services.AddLogging(builder => builder.AddSerilog(dispose: true));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//cache
builder.Services.AddDistributedMemoryCache();
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
Data.DependencyInjection.DIConfig.ConfigureServices(builder.Services, builder.Configuration);
Infrastructure.DependencyInjection.DIConfig.ConfigureServices(builder.Services);
WebAPI.DependencyInjection.DIConfig.ConfigureServices(builder.Services, builder.Configuration);

builder.Services
    .AddInfrastructureLayer()
    .AddDataLayer()
    .AddServiceLayer()
    ;



var app = builder.Build();

app.UseExceptionHandler("/Error");

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {


        // Write the response as JSON
        var result = System.Text.Json.JsonSerializer.Serialize(new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(e => new
            {
                name = e.Key,
                status = e.Value.Status.ToString(),
                description = e.Value.Description,
                duration = e.Value.Duration.TotalMilliseconds
            }),
            totalDuration = report.TotalDuration.TotalMilliseconds
        });

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }
});


app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<TestMiddleware>();

app.MapControllers();

app.Run();