using APIFuncionariosIF.DataContext;
using APIFuncionariosIF.Interface;
using APIFuncionariosIF.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var defaultConnection = "server=localhost;userid=root;password=895smigol;database=APIFuncionariosIF;";

builder.Services.AddScoped<APIFuncionariosIFContext>();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

builder.Services.AddDbContext<APIFuncionariosIFContext>(options =>
{
    options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
});

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
