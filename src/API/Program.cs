using API.Extensions;
using API.MapperStorage;
using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<VapeContext>(options => options.UseSqlServer(connection));

builder.Services.AddDomainServices();
builder.Services.AddDataLayerRepository();
builder.Services.AddAutoMapper(typeof(MapperProfile));

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
