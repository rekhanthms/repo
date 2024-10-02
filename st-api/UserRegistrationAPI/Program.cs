using Microsoft.EntityFrameworkCore;
using UserRegistrationAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Add MySQL and UserContext to the services
builder.Services.AddDbContext<UserContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Add CORS if Angular and .NET are on different origins (optional but recommended)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// 3. Add controllers
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

// app.UseHttpsRedirection();

// 4. Enable CORS middleware (if CORS was added)
app.UseCors("AllowAll");

app.UseAuthorization();

// Map the controllers to the routes
app.MapControllers();

app.Run();

Console.Write("I'm working");
