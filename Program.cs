using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserControl.Context;
using UserControl.Interfaces;
using UserControl.Models;
using UserControl.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

Console.WriteLine(Environment.GetEnvironmentVariable("SmtpServer"));
Console.WriteLine(Environment.GetEnvironmentVariable("Port_Email"));
Console.WriteLine(Environment.GetEnvironmentVariable("From"));
Console.WriteLine(Environment.GetEnvironmentVariable("Password"));

string connectionString = Environment.GetEnvironmentVariable("connString");

builder.Services.AddDbContext<DataBaseContext>(opts =>
opts.UseSqlServer(connectionString));

builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<int>>(
    opt =>
    {
        opt.SignIn.RequireConfirmedEmail = true;
        opt.User.RequireUniqueEmail = true;
    }

    )
    .AddEntityFrameworkStores<DataBaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IRegisterUser, RegisterUserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILogoutService, LogoutService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UserControl",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
