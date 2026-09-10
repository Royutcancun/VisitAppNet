using Application.UseCases.Persons;
using Data;
using Data.Repositories;
using Domain;
using Domain.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Database connection is missing");

builder.Services.AddData(connectionString);
//builder.Services.AddScoped<IRepository<PersonEntity, Guid>, PersonRepository>();
//builder.Services.AddScoped<ICodeRepository<PersonEntity>, PersonRepository>();

builder.Services.AddScoped<CreatePersonUseCase>();
builder.Services.AddScoped<DeletePersonUseCase>();
builder.Services.AddScoped<GetAllPersonsUseCase>();
builder.Services.AddScoped<GetPersonByIdUseCase>();
builder.Services.AddScoped<GetPersonByCodeUseCase>();
builder.Services.AddScoped<UpdatePersonUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();
