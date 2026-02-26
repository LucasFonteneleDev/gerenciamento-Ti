using gerenciamento_Ti.Database;
using gerenciamento_Ti.Services.Implementation;
using gerenciamento_Ti.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GerenciamentoDbContext>(op => op.UseNpgsql(connString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//forma fácil de corrigir problemas com datas nos objetos

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<ITipoEquipamentoService, TipoEquipamentoService>();
builder.Services.AddScoped<IEquipamentoService, EquipamentoService>();

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
