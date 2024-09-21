using BookingHotel_Application.BLL.Service;
using BookingHotel_Application.BLL.Service.IService;
using BookingHotel_Application.DAL.Repository;
using BookingHotel_Application.DAL.Repository.IRepository;
using BookingHotel_Application.DAL.UoW.IUoW;
using BookingHotel_Application.DAL.UoW;
using BookingHotel_Application.Model.Data;
using BookingHotel_Application.Model.Helper;
using BookingHotel_Application.Model.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddDbContext<AppDbContext>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("DB");
    option.UseSqlServer(connectionString);
});


// Inject app Dependency Injection
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddSingleton<JwtHelper>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Bear
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: Bearer Generated-JWT-Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[] { }
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowSpecificOrigin");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    if (!app.Environment.IsDevelopment())
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API");
        c.RoutePrefix = string.Empty;
    }
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();