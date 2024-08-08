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


//שולחת לפונקציה חיצונית שתטפל בכל ההפניות
//Accessories.AddDependencies.AddAllDependencies(builder.Services);
//או על ידי פונקצית הרחבה::
 builder.Services.AddAllDependencies();


var connectionString = builder.Configuration.GetConnectionString("SchollConnStr");
//אם רוצים את מחרוזת החיבור במחלקה אחרת או בשכבה אחרת,
// כך ניתן לכאורה להזריק את מחרוזת החיבור
 // builder.Services.AddSingleton<string >(connectionString);
 
//או שאפשר גם להזריק את כל אוביקט ה-configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

 //builder.Services.AddAutoMapper(typeof( SchoolMapperConfig ));
// builder.Services.AddSingleton(typeof( MapperConfiguration  ), typeof(SchoolMapperConfig));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<SchoolAPI.SchoolMapperConfig >()); // or your profile's assembly
 

//אפשרויות התיעוד:
//Console
//Debug
//EventSource
//EventLog: Windows only
//הוספת הזרקת תלות לצורך logging
builder.Logging.ClearProviders();
builder.Logging.AddDebug ();
builder.Logging.AddConsole ();
 
//builder.Logging.AddEventLog();

#region log to Events viewer:
  
string sourceName = "Web api logs";

if (!EventLog.SourceExists(sourceName))
    // מחפש אם מקור הרישומים קיים ברשימה
    EventLog.CreateEventSource(sourceName, "Application");

 
//ניתן להפעיל רק כמנהל מערכת - admin
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
    Debug.Print(" myMiddleareLogic הבקשה עברה דרך  הפונקציה ");
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
