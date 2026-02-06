using Restaurant.Application.Extensions;
using Restaurant.Infrastructure.Extensions;
using Restaurant.UI.Midleware;
using Serilog;
using Serilog.Events;
using Restaurant.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddAutoMapper(typeof(ReviewProfile));
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Host.UseSerilog((context, config) =>
//config.ReadFrom.Configuration(builder.Configuration)
config.MinimumLevel.Override("Microsost", LogEventLevel.Warning)
.MinimumLevel.Override("MicrosoftEntityFrameworkCore", LogEventLevel.Information)
.WriteTo.File("Logs/Api-logs-.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
.WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] {Message:lj}{NewLine} |{SourceContext}|{NewLine}{Exception}")
);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseAuthorization();
//app.UseRouting();

//app.MapIdentityApi<User>();

app.MapControllers();

app.Run();
