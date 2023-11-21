using MediTechSolution_mainProject.API.AutoMapperProfile;
using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Services.Interfaces;
using MediTechSolution_mainProject.API.Services.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicatinDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MediTechConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<ILogin, LoginRepository>();
builder.Services.AddScoped<IDoctorLogin, DoctorLoginRepository>();
builder.Services.AddScoped<IHospitalCity, AddHospitalCitiesRepository>();
builder.Services.AddScoped<IMedicalSpeciality, MedicalSpecialityRepository>();
builder.Services.AddScoped<ICollegesUniversity, CollegeUniversityRepository>();
builder.Services.AddScoped<ICourseDetails, CourseDetailsRepository>();
builder.Services.AddScoped<IDoctor, DoctorRepository>();
builder.Services.AddScoped<IFindADoctor, FindADoctorRepository>();
builder.Services.AddScoped<IAppointmentToClient, AddAppointmentToClientRepository>();
builder.Services.AddScoped<IContact, ContactRepository>();
builder.Services.AddScoped<IMediceneCategory, MediceneCategoryRepository>();
builder.Services.AddScoped<IMediceneByCategory, MediceneByCategoryRepository>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:3000", "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWTToken:Issuer"],
            ValidAudience = builder.Configuration["JWTToken:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:Key"]))
        };
    });

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
