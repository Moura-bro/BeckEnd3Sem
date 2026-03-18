using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using EventPlus.WebAPI.Repositoriesp;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<EventContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//2. Registrar os repositórios (Injesao de Dependecia)
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<IInstitucaoRepository, InstitucaoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();


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
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-dev")),
            //Valida o tempo de expiracao do tonken
            ClockSkew = TimeSpan.FromMinutes(5),
            //nome do issuer (de onde esta vindo)
            ValidIssuer = "api_eventplus",
            //nome do audience(para onde esta indo)
            ValidAudience = "api_eventplus"
        };
    });


//Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "API para gerenciamento de eventos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Equipe EventPlus",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Licença de Exemplo",
            Url = new Uri("https://example.com/license")
        }
    });

// Usando a autenticao no Swagger
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Insira o token JWT:"
});

options.AddSecurityRequirement(document => new  OpenApiSecurityRequirement
{
    [new OpenApiSecuritySchemeReference("Bearer", document )] = Array.Empty<string>().ToList()

});

});



builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

        app.UseSwagger(options => { });

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty; // Define a raiz para acessar o Swagger UI
        });
}


app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

//------------Sei la
app.UseHttpsRedirection();

// Adiciona o mapeamentos de Controllers

app.MapControllers();

app.Run();
