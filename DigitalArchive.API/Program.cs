using Autofac;
using Autofac.Extensions.DependencyInjection;
using DigitalArchive.Business;
using DigitalArchive.Business.DependencyResolvers.Autofac;
using DigitalArchive.Core.Extensions.ResponseAndExceptionMiddleware;
using DigitalArchive.Core.Utilities.Security.Encryption;
using DigitalArchive.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

//builder.Logging.AddProvider(new FileLoggerProvider());
//Bunu AutofacBusinessModule taþý !!!
builder.Services.AddDependencyResolver();
//Autofac Dependency ve Aspect Çözümü
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

//const string corsName = "cors";
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbConnectionServices();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();
//jwt Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
            ValidAudience = builder.Configuration["TokenOptions:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(builder.Configuration["TokenOptions:SecurityKey"])
        };
    });

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        p => p.AllowAnyOrigin().
//            AllowAnyHeader().
//            AllowAnyMethod().
//            AllowCredentials()
//            );
//});
//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy(corsName,
//        policy =>
//        {
//            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
//        });
//});

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("DigitalArchiveApi", new OpenApiInfo
    {
        Version = "v1",
        Title = "DigitalArchive API",
        Description = "A simple example ASP.NET Core Web API",
        Contact = new OpenApiContact
        {
            Name = "Emre Dindar",
            Email = "emredindr@gmail.com",
            Url = new Uri("https://emredindr.github.io"),
        },
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/DigitalArchiveApi/swagger.json", "DigitalArchive API");
    });
}


app.UseApiResponseAndExceptionWrapper();

app.UseAuthentication();
app.UseAuthorization();
//app.UseCors(corsName);

//Burası geliştirilecek Cors için izin verilecek adresler configden oluşturulacak

//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.Run();
