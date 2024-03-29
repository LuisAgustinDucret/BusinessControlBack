
using BusinessControlBackEnd.Repositories;
using BusinessControlBackEnd.Repositories.Repository;
using BusinessControlBackEnd.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();

builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.d
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetService<StoreService>();
app.Services.GetService<UnidadMedidaService>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
