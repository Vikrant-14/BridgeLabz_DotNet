using CQRSPattern.BusinessLayer.Interface;
using CQRSPattern.BusinessLayer.Service;
using CQRSPattern.Context;
using CQRSPattern.Handlers.StudentHandler;
using CQRSPattern.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

//Student
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentBL,StudentBL>();

builder.Services.AddTransient<CreateStudentHandler>();
builder.Services.AddTransient<DeleteStudentHandler>();
builder.Services.AddTransient<UpdateStudentHandler>();
builder.Services.AddTransient<GetStudentListHandler>();
builder.Services.AddTransient<GetStudentByIdHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
