using DistributedPlatform.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=:memory:"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
    
    if (!dbContext.Tasks.Any())
    {
        dbContext.Tasks.AddRange(
            new DistributedPlatform.Sync.Models.TaskItem 
            { 
                Id = 1, 
                Title = "Изучить ASP.NET Core", 
                Description = "Освоить создание Web API", 
                IsCompleted = false 
            },
            new DistributedPlatform.Sync.Models.TaskItem 
            { 
                Id = 2, 
                Title = "Создать клиентское приложение", 
                Description = "Реализовать UI на Blazor", 
                IsCompleted = true 
            }
        );
        dbContext.SaveChanges();
    }
}

app.Run();