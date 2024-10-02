using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt=>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
 {
   app.UseSwagger();
   app.UseSwaggerUI();
 }

app.UseCors(x=> x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200"));
// app.UseHttpsRedirection();

// IApplicationBuilder applicationBuilder = app.UseAuthorization();

app.MapControllers();

// Serve favicon.ico
////app.MapGet("/favicon.ico", async context =>
//{
    //await context.Response.SendFileAsync("wwwroot/favicon.ico");
//});

app.Run();
