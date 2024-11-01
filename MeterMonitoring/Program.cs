using DatabaseLibrary.Data;
using Microsoft.EntityFrameworkCore;
using MeterMonitoring.Data.Services.Extensions;
using MeterMonitoring.Data.Mapper.Extensions;
using MeterMonitoring.Common.Services.Concretes;
using MeterMonitoring.Rabbit.Consumer.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MeterMonitoringContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddProjectServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMappers();
builder.Services.AddSingleton<RabbitMqService>();

var builders = Host.CreateDefaultBuilder(args);
builders.ConfigureServices((hostContext, services) =>
{
    // RabbitMQConsumer'ý arka plan servisi olarak ekle
    services.AddHostedService<RequestConsumerManager>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();