using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPIProjectPractice.DataAccess.IRepository;
using WebAPIProjectPractice.DataAccess.Repository;
using WebAPIProjectPractice.DataBaseAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(Options=>Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDeptRepo,DeptRepo>();
builder.Services.AddTransient<IEmpRepo,EmpRepo>();

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
