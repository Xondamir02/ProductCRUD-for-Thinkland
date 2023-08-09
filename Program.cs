using Microsoft.EntityFrameworkCore;
using ProductCRUD.Context;
using ProductCRUD.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    options.UseNpgsql("Server=localhost;Port=5440;Database=postgres;User Id=postgres; Password=postgres");
});
builder.Services.AddScoped<IProductManager, ProductManager>();
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
