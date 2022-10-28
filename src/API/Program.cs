using API.Extensions;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddDomainServices();
builder.Services.AddDataLayerRepository();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.SetIsOriginAllowed(origin => true)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});

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
