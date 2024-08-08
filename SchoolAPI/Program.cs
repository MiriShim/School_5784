using Accessories;

using IBL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using SchoolAPI;
using SchoolDAL;
using SchoolDAL.Model;
using System.Diagnostics;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//����� �������� ������� ����� ��� �������
Accessories.AddDependencies.AddAllDependencies(builder.Services);
//�� �� ��� ������� �����::
//builder.Services.AddAllDependencies();


var connectionString = builder.Configuration.GetConnectionString("SchollConnStr");
//�� ����� �� ������ ������ ������ ���� �� ����� ����,
// �� ���� ������ ������ �� ������ ������
//builder.Services.AddSingleton<UserGittyDbContext>(new UserGittyDbContext(connectionString));
 
//�� ����� �� ������ �� �� ������ �-configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);



//�������� ������:
//Console
//Debug
//EventSource
//EventLog: Windows only
//����� ����� ���� ����� logging
builder.Logging.ClearProviders();
builder.Logging.AddDebug ();
builder.Logging.AddEventSourceLogger  ();


#region Events viewer:
  
string sourceName = "Web api logs";

if (!EventLog.SourceExists(sourceName))

    // ���� �� ���� �������� ���� ������
    EventLog.CreateEventSource(sourceName, "Application");

 
//���� ������ �� ����� ����� - admin
builder.Logging.AddEventLog(eventLogSettings =>
{
    eventLogSettings.SourceName = sourceName;
});



#endregion

 
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

app.Use(async (context, next) =>
{
    var cultureQuery = context.Request.Query["culture"];
    if (!string.IsNullOrWhiteSpace(cultureQuery))
    {
        var culture = new CultureInfo(cultureQuery);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }
        Debug.Print(
            $" ****  CurrentCulture.DisplayName:  {  CultureInfo.CurrentCulture.DisplayName}");

    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.UseShabatMiddleware();

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync(
//        $"****  CurrentCulture.DisplayName:  {  CultureInfo.CurrentCulture.DisplayName}");
//});

app.Run();
