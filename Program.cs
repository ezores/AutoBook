using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using UstamOgretiyorBize.DBu;
using UstamOgretiyorBize.Exceptions;
using UstamOgretiyorBize.Logging;

//AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
} );
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.UseMiddleware(typeof(ExceptionHandlerMiddleware)); //2 ways of doing it Ustam cok iyi yav
app.UseMiddleware<LoggingMiddleware>();

app.Run();
