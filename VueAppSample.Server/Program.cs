using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Configuration;
using VueAppSample.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// インメモリ
//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext") ?? throw new InvalidOperationException("Connection string 'TodoContext' not found.")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORSオリジン設定
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()   // すべてのオリジンからのアクセスを許可
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS ミドルウェアを有効にする
app.UseCors("AllowAll"); // ポイント！！！ ←　app.UseStaticFiles()の前に移動。

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
