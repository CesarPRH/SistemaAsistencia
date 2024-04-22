using Microsoft.EntityFrameworkCore;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services;
using SistemaAsistencia.Services.Carreras;
using SistemaAsistencia.Services.Courses;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddScoped<ICareerService, CareerService>();
builder.Services.AddScoped<IcourseService, CourseService>();
builder.Services.AddDbContext<SystemDatabaseContext>(
    options => {        //TODO: Cambiar el Usuario a un usuario que no sea root.
        options.UseMySQL("Server=localhost;Database=pruebabrotha;Uid=root;Pwd=sasa");
      }
);

var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
