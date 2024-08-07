using Accessories;

using IBL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using SchoolDAL;
using SchoolDAL.Model;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//שולחת לפונקציה חיצונית שתטפל בכל ההפניות
Accessories.AddDependencies.AddAllDependencies(builder.Services);
//או על ידי פונקצית הרחבה::
//builder.Services.AddAllDependencies();


var connectionString = builder.Configuration.GetConnectionString("SchollConnStr");
//אם רוצים את מחרוזת החיבור במחלקה אחרת או בשכבה אחרת,
// כך ניתן לכאורה להזריק את מחרוזת החיבור
//builder.Services.AddSingleton<UserGittyDbContext>(new UserGittyDbContext(connectionString));
 
//או שאפשר גם להזריק את כל אוביקט ה-configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);



//אפשרויות התיעוד:
//Console
//Debug
//EventSource
//EventLog: Windows only
//הוספת הזרקת תלות לצורך logging
builder.Logging.ClearProviders();
builder.Logging.AddDebug ();
builder.Logging.AddEventSourceLogger  ();


#region Events viewer:
  
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


#region כאן למדנו על פונקציות הרחבה - extension methods
string s = "אבא";

//int gimatria = new Accessories.ExtensionMethods().GetGimatria(s);
int gimatria2 = Accessories.ExtensionMethods.StaGetGimatria(s);

int gimatria = "תמר".GetGimatria(); 
#endregion


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
