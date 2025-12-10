using FitnessMember.Data;
using Microsoft.EntityFrameworkCore; 
using FitnessMember.Repositories; 


//builder pattern to configure and run the web application, so what services it will use
//before the app starts responding to HTTP requests
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();  //tells the app to use Swagger, and to prepare a Swagger generator

// register controllers (this enables [ApiController] classes)
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


//after we added the connection string in appsettings.json, we can retrieve it from there
builder.Services.AddDbContext<FitnessDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// register the MemberRepository for dependency injection, so it can be used in controllers
//AddScoped means a new instance is created per HTTP request
builder.Services.AddScoped<IMemberRepository, MemberRepository>();



var app = builder.Build(); //how the app will respond to HTTP requests

if (app.Environment.IsDevelopment())    //checks if the app is running in development mode or production mode, this is checkes from the launch settings
{
    //activate Swagger middleware (this serves the generated Swagger as a JSON endpoint)
    app.UseSwagger();
    //activate Swagger UI middleware (this serves the Swagger UI)
    app.UseSwaggerUI();
}

app.UseAuthorization();

// map attribute-routed controllers (e.g. [Route("api/[controller]")])
app.MapControllers();

app.Run();