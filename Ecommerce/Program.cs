using Ecommerce.Repository.Implementation;
using Ecommerce.Repository.Interface;
using Ecommerce.Server;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var key = builder.Configuration.GetSection("JWTAuthenticationParams").GetValue<string>("PrivateKey");

if(key == null)
{
    throw new ApplicationException("Not Found");
}
builder.Services.AddSingleton<IAuthenticationManager>(new AuthenticationManager(key));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = true,
        ValidIssuer="App.Identity",
        ValidateAudience = true,
        ValidAudience="Audience.Main"

    };



});

builder.Services.AddCors(p => p.AddPolicy("corspolicy",
    build =>
    {

        build.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    }




    ));














var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("corspolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
