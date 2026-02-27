using FilmesMoura.WebAPI.BdContextFilme;
using FilmesMoura.WebAPI.Interfaces;
using FilmesMoura.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// adiciona o contexto do banco de dados 
builder.Services.AddDbContext<FilmeContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaltConnection")));

//Adiciona o repositorio
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adicionar servicos de jwt Bearrer(forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearrer";
    options.DefaultChallengeScheme = "JwtBearrer";

})
    .AddJwtBearer("JwtBearrer", options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //valida quem esta solicitando o token
            ValidateIssuer = true,
            //valida quem esta recebendo o token
            ValidateAudience = true,
            //valida o tempo de expiração do token
            ValidateLifetime = true,
            //Forma de Criptografia e valida  a chave de autentificacao
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),
            //Valida o tempo de expiracao do tonken
            ClockSkew = TimeSpan.FromMinutes(5),
            //nome do issuer (de onde esta vindo)
            ValidIssuer = "api_filmes",
            //nome do audience(para onde esta indo)
            ValidAudience = "api_filmes"
        };
    });


//Adiciona serviços de controler 
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

// Adiciona o mapeamentos de Controllers

app.MapControllers();

app.Run();
