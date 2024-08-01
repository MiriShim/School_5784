using Accessories;

using IBL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAllDependencies();


//שולחת לפונקציה חיצונית שתטפל בכל ההפניות
  Accessories.AddDependencies.AddAllDependencies(builder.Services);
 


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
