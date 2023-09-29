using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


//Adiciona serviço de JWT Bearer (Forma de autenticação)
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultChallengeScheme = "JwtBearer";
    Options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        //Valida que está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração será validado
        ValidateLifetime = true,

        //Forma de criptografia e valida a chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-webapi-chaves-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //Nome do issuer (De onde está vindo)
        ValidIssuer = "HealthClinic_API",

        //Nome do audience (Para Onde está indo)
        ValidAudience = "HealthClinic_API"
    };

});


//Adicione o gerador do swagger á coleção de serviços e editar os nomes
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Health Clinic",
        Description = "API para uma empresa de consultas médicas - sprint 2 - Backend API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Gabriel Coral Russo - Aluno Senai",
            Url = new Uri("https://github.com/GCRusso")
        },
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

//Aqui comeca a configuração do SWAGGER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
// Termina a configuracao do SWAGGERS

// Aqui adiciona autenticação 
app.UseAuthentication();


// Aqui adiciona autorização
app.UseAuthorization();

app.UseHttpsRedirection();

// Aqui adiciona autorização
app.UseAuthorization();

//Adiciona o mapeamento dos controllers
app.MapControllers();

app.Run();