using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Infrastructure.Context;
using ProdutosAPI.Domain.Interfaces;
using ProdutosAPI.Infrastructure;
using ProdutosAPI.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // ✅ origem do Angular
              .AllowAnyHeader()
              .AllowAnyMethod(); // permite POST, GET, etc
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<Iproduto, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowLocalhost4200");
app.UseAuthorization();
app.MapControllers();
app.Run();
