using Microsoft.OpenApi.Models;
using Application;
using Infrastructure;
using NLog;
using NLog.Web;
using Utilities;

var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{
    logger.Info("Starting up...");
    var builder = WebApplication.CreateBuilder(args);

    //============ NLog ============//
    builder.Logging.ClearProviders(); // Xoá logging provider mặc định
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog(); // NLog.Web

    //builder.Services.AddHttpContextAccessor();

    //============ Config Persistence and Application Project ============//
    builder.Services.ConfigurePersistence(builder.Configuration);
    builder.Services.ConfigureApplication();

    //============ AutoMapper ============//
    builder.Services.AddAutoMapper(typeof(Program));

    //============ CORS ============//
    //builder.Services.AddCors();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tran Huu Tri - JMS API", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
        });
    });

    var app = builder.Build();
    Utilities.HttpContext.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
    app.UseMiddleware<ErrorHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseCors(builder =>
    //{
    //    builder.AllowAnyHeader()
    //    .AllowAnyOrigin()
    //    .AllowAnyMethod();
    //});

    //Cho phép frontend gọi API từ bất kỳ domain nào(AllowAnyOrigin).
    //Tránh lỗi CORS khi dùng HTTPS.
    app.UseCors("AllowAll"); 

    app.UseHttpsRedirection(); // Tự động redirect HTTP → HTTPS nếu HTTPS được bật

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
