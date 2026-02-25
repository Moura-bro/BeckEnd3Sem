using FilmesMoura.WebAPI.BdContextFilme;
using FilmesMoura.WebAPI.Interfaces;
using FilmesMoura.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// adiciona o contexto do banco de dados 
builder.Services.AddDbContext<FilmeContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaltConnection")));

//Adiciona o repositorio
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

//Adiciona serviços de controler 
builder.Services.AddControllers();

var app = builder.Build();

// Adiciona o mapeamentos de Controllers

app.MapControllers();

app.Run();
