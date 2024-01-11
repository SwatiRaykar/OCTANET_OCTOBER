
using DAL.Interface;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Configuration;
using UdemyProj;
using UdemyProj.Repository;
using Configuration = System.Configuration.Configuration;
//using UdemyProj.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();//Dependency injection

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddControllers();

//builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();//Dependency injection

//injecting DbContext Class and provinding conn string to this DbContext Class
//builder.Services.AddDbContext<UdemyProjDbContext>(options=>
//options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks")));//Dependency injection


var app = builder.Build();

//for html code execution
//app.UseHttpsRedirection();

//var options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("HTMLPage2.html");
//.DefaultFileNames.Add("Registration.html");

//app.UseDefaultFiles(options);
//app.UseStaticFiles();
//app.UseRouting();
//end html  ..

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy"); 
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
