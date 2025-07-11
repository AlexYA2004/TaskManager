using Nest;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() 
    .Enrich.FromLogContext()
    .Enrich.WithProperty("Application", "TaskManager.API")
    .WriteTo.Console()
    .WriteTo.File("C:\\Users\\aakim\\OneDrive\\Desktop\\logs.txt.txt")
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        IndexFormat = "api-logs",
        AutoRegisterTemplate = true,
        NumberOfShards = 1, 
        NumberOfReplicas = 0,
        ModifyConnectionSettings = x => x
            .ServerCertificateValidationCallback((o, cert, chain, errors) => true)
            .DisableAutomaticProxyDetection(),
        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
    })
    .CreateLogger();


builder.Host.UseSerilog();
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

