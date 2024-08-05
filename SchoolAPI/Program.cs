using Accessories;

using IBL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using SchoolDAL;
using SchoolDAL.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAllDependencies();


var connectionString = builder.Configuration.GetConnectionString("SchollConnStr");
//�� ����� �� ������ ������ ������ ���� �� ����� ����,
// �� ���� ������ ������ �� ������ ������
//builder.Services.AddSingleton<UserGittyDbContext>(new UserGittyDbContext(connectionString));
 
//�� ����� �� ������ �� �� ������ �-configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


//����� �������� ��� ���� �� ��� ����:
builder.Services.AddDbContext<SchoolDbContext >(options =>
    options.UseSqlServer(connectionString));


//����� �������� ������� ����� ��� �������
Accessories.AddDependencies.AddAllDependencies(builder.Services);
 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region ��� ����� �� �������� ����� - extension methods
string s = "���";

//int gimatria = new Accessories.ExtensionMethods().GetGimatria(s);
int gimatria2 = Accessories.ExtensionMethods.StaGetGimatria(s);

int gimatria = "���".GetGimatria(); 
#endregion


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
