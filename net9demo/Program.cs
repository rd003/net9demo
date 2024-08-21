using FluentValidation;
using Microsoft.AspNetCore.Identity;
using net9demo.Models;
using net9demo.Repositories;
using net9demo.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddScoped<IValidator<Person>, PersonValidator>();
//builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

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
