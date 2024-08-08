using Accessories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SchoolAPI;
using System.Diagnostics;
using System.Globalization;
 
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();   
//
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//����� �������� ������� ����� ��� �������
//Accessories.AddDependencies.AddAllDependencies(builder.Services);
//�� �� ��� ������� �����::
 builder.Services.AddAllDependencies();


var connectionString = builder.Configuration.GetConnectionString("SchollConnStr");
//�� ����� �� ������ ������ ������ ���� �� ����� ����,
// �� ���� ������ ������ �� ������ ������
 // builder.Services.AddSingleton<string >(connectionString);
 
//�� ����� �� ������ �� �� ������ �-configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

 //builder.Services.AddAutoMapper(typeof( SchoolMapperConfig ));
// builder.Services.AddSingleton(typeof( MapperConfiguration  ), typeof(SchoolMapperConfig));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<SchoolAPI.SchoolMapperConfig >()); // or your profile's assembly
 

//�������� ������:
//Console
//Debug
//EventSource
//EventLog: Windows only
//����� ����� ���� ����� logging
builder.Logging.ClearProviders();
builder.Logging.AddDebug ();
builder.Logging.AddConsole ();
 
//builder.Logging.AddEventLog();

#region log to Events viewer:
  
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

//Middleware:
app.Use(myMiddleareLogic);

RequestDelegate myMiddleareLogic(RequestDelegate @delegate)
{
    Debug.Print(" myMiddleareLogic ����� ���� ���  �������� ");
    return @delegate ;
}

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

//app.UseMiddleware<ShabatMiddleware>();

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync(
//        $"****  CurrentCulture.DisplayName:  {  CultureInfo.CurrentCulture.DisplayName}");
//});

app.Run();
