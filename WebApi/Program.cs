using Data.DependencyInjection;
using Infrastructure.DependencyInjection;
using Service.DependencyInjection;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);


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

builder.Services.AddInfrastructureLayer().AddDataLayer().AddServiceLayer();



var app = builder.Build();

app.UseExceptionHandler("/Error");
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

app.MapControllers();

app.Run();